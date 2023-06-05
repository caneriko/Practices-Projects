using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.ViewModels.User;
using Victory.Service.Extensions;
using Victory.Service.Services;
using Victory.Service.ToastrMessages;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IToastNotification _toast;
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUser> _validator;


        public UserController(IUserService userService, IToastNotification toast, UserManager<AppUser> userManager, IMapper mapper, IValidator<AppUser> validator)
        {
            _userService = userService;
            _toast = toast;
            _userManager = userManager;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _userService.GetUserListAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Roles = await _userService.GetRolesAsync();


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel viewModel)
        {
            ViewBag.Roles = await _userService.GetRolesAsync();


            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<AppUser>(viewModel);

                var validation = await _validator.ValidateAsync(entity);

                if (validation.IsValid)
                {
                    var result = await _userService.AddAsync(viewModel);

                    if (result.Succeeded)
                    {
                        _toast.AddSuccessToastMessage(ResultMessage.User.Add(viewModel.UserName), new ToastrOptions { Title = "Başarılı" });
                        return RedirectToAction("Index", "User", new { Area = "Admin" });

                    }
                    else
                    {

                        result.AddToIdentityModelState(this.ModelState);
                        return View();

                    }

                }
                else
                {
                    validation.AddToModelState(this.ModelState);
                    return View();

                }
            }

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var viewModel = await _userService.GetUserByIdAsync(id);

            ViewBag.Roles = await _userService.GetRolesAsync();

            ViewBag.Role = await _userService.GetUserRoleIdAsync(id);


            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel viewModel)
        {

            ViewBag.Roles = await _userService.GetRolesAsync();

            var user = await _userService.GetAppUserByIdAsync(viewModel.Id);

            if (user != null)
            {

                if (ModelState.IsValid)
                {

                    var map = _mapper.Map(viewModel, user);

                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.SecurityStamp = Guid.NewGuid().ToString();

                        var result = await _userService.UpdateAsync(viewModel);

                        if (result.Succeeded)
                        {
                            _toast.AddSuccessToastMessage(ResultMessage.User.Update(viewModel.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
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
                else
                {
                    return View(viewModel);
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _userService.DeleteAsync(id);

            if (result.identityResult.Succeeded)
            {
                _toast.AddSuccessToastMessage(ResultMessage.User.Delete(result.userName), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }

            return NotFound();
        }


        public async Task<IActionResult> Profile(string name)
        {

            var viewModel = await _userService.ProfileAsync(name);


            return View(viewModel);
        }

    }
}
