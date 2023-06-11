using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.Services;
using BookSaw.Core.ViewModels.Category;
using BookSaw.Core.ViewModels.Role;
using BookSaw.Core.ViewModels.User;
using BookSaw.Service.Extensions;
using BookSaw.Service.Messages;
using BookSaw.Service.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace BookSaw.Web.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IToastNotification _toast;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUser> _validator;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;


        public AdminController(IUserService userService, IToastNotification toast, IMapper mapper, IValidator<AppUser> validator, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _toast = toast;
            _mapper = mapper;
            _validator = validator;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = await _userService.GetAllAsync();

            return View(viewModel);
        }


        [HttpGet]

        public async Task<IActionResult> UserProfile()
        {
            var userProfile = await _userService.GetUserProfileAsync(User.Identity!.Name!);

            var viewModel = new AdminUserProfileViewModel()
            {
                UserProfile = userProfile,
                PasswordChange = new()

            };


            return View(viewModel);

        }


        [HttpPost]

        public async Task<IActionResult> PasswordChange(UserChangePasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var passwordCheck = await _userService.CheckPasswordAsync(User.Identity.Name, viewModel);

                if (passwordCheck)
                {
                    var passwordResult = await _userService.ChangePasswordAsync(User.Identity.Name, viewModel);

                    if (passwordResult.Succeeded)
                    {
                        _toast.AddSuccessToastMessage(ResultMessage.User.PasswordChange());
                        return RedirectToAction("Login", "Auth", new { Area = "Admin" });
                    }

                    passwordResult.AddToIdentityModelState(this.ModelState);

                }

            }
            _toast.AddErrorToastMessage("Password couldn't be changed");

            return RedirectToAction("UserProfile", "Admin", new { Area = "Admin" });

        }

        public async Task<IActionResult> UserUpdate()
        {
            var viewModel = await _userService.GetUserUpdateModelAsync(User.Identity!.Name!);

            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> UserUpdate(UserUpdateViewModel viewModel)
        {

            var user = await _userService.GetAppUserByIdAsync(viewModel.Id);

            if (user != null)
            {

                var map = _mapper.Map(viewModel, user);

                var validation = await _validator.ValidateAsync(map);


                if (validation.IsValid)
                {

                    var result = await _userService.UpdateUserAsync(viewModel);

                    if (result.Succeeded)
                    {
                        _toast.AddSuccessToastMessage(ResultMessage.User.Update(viewModel.UserName));
                        return RedirectToAction("UserProfile", "Admin", new { Area = "Admin" });
                    }
                    else
                    {
                        result.AddToIdentityModelState(this.ModelState);
                        return View(viewModel);
                    }
                }
                else
                {
                    validation.AddToModelState(this.ModelState);
                    return View(viewModel);

                }

            }
            return NotFound();


        }


        [HttpGet]
        public IActionResult RoleAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleAdd(RoleAddViewModel viewModel)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Name = viewModel.Name! });

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();
                return RedirectToAction("RoleList", "Admin", new {Area="Admin"});
            }

            _toast.AddErrorToastMessage();
            result.AddToIdentityModelState(this.ModelState);
            return View();
        }


        public async Task<IActionResult> RoleList()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = _mapper.Map<List<RoleListViewModel>>(roles);

            return View(viewModel);


        }

        public async Task<IActionResult> RoleUpdate(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            var viewModel = _mapper.Map<RoleUpdateViewModel>(role);

            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel viewModel)
        {
            var role = await _roleManager.FindByIdAsync(viewModel.Id.ToString());

            role.Name = viewModel.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();
                return RedirectToAction("RoleList", "Admin", new { Area = "Admin" });
            }

            _toast.AddErrorToastMessage();
            result.AddToIdentityModelState(this.ModelState);
            return View();
        }


        public async Task<IActionResult> RoleDelete(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();
                return RedirectToAction("RoleList", "Admin", new { Area = "Admin" });

            }

            _toast.AddErrorToastMessage();
            result.AddToIdentityModelState(this.ModelState);
            return RedirectToAction("RoleList", "Admin", new { Area = "Admin" });

        }

        public async Task<IActionResult> AssignToRoleUser(int id)
        {
            ViewBag.userid = id;
            var user = await _userManager.FindByIdAsync(id.ToString());

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            var roleViewModelList = new List<AssignRoleToUserModel>();

            foreach (var role in roles)
            {
                var assignRoleToUserModel = new AssignRoleToUserModel() { Id = role.Id, Name = role.Name };

                if (userRoles.Contains(role.Name))
                {
                    assignRoleToUserModel.Exists = true;
                }

                roleViewModelList.Add(assignRoleToUserModel);

            }

            return View(roleViewModelList);

        }


        [HttpPost]
        public async Task<IActionResult> AssignToRoleUser(int id, List<AssignRoleToUserModel> viewModels)
        {

            var userToAssignRoles = await _userManager.FindByIdAsync(id.ToString());


            foreach (var role in viewModels)
            {
                if (role.Exists)
                {
                   await  _userManager.AddToRoleAsync(userToAssignRoles, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(userToAssignRoles, role.Name);
                }

            }


            return RedirectToAction("RoleList", "Admin", new { Area = "Admin" });



        }




    }

}

