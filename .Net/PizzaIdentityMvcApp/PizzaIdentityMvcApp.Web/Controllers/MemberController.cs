using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PizzaIdentityMvcApp.Core.Entities;
using PizzaIdentityMvcApp.Core.ViewModels.Role;
using PizzaIdentityMvcApp.Core.ViewModels.User;
using PizzaIdentityMvcApp.Service.Helpers;

namespace PizzaIdentityMvcApp.Web.Controllers
{
    //[Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IToastNotification _toast;
        private readonly IImageHelper _imageHelper;


        public MemberController(SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IToastNotification toast, UserManager<AppUser> userManager, IImageHelper imageHelper)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _toast = toast;
            _userManager = userManager;
            _imageHelper = imageHelper;
        }




        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
                
        }


        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();

            var viewModel = new List<UserListViewModel>();

            foreach (var item in users)
            {
                viewModel.Add(new() { Id = item.Id, Email = item.Email, FullName = item.FullName, UserName = item.UserName });

            }

            return View(viewModel);
        }



        [HttpGet]

        public async Task<IActionResult> UserProfile()
        {
           string name = User.Identity!.Name!;

            var user =await  _userManager.FindByNameAsync(name);

            var viewModel = new UserProfileViewModel()
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                PictureUrl=user.PictureUrl
                
            };

            return View(viewModel);
        }

        public async Task<IActionResult> UserUpdate()
        {

            string name = User.Identity!.Name!;

            var user = await _userManager.FindByNameAsync(name);

            var viewModel = new UserUpdateViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                PictureUrl = user.PictureUrl,
                FullName = user.FullName

            };


            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserUpdate(UserUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(); 
            }

            var user = await _userManager.FindByIdAsync(viewModel.Id);

            user.FullName= viewModel.FullName;
            user.PhoneNumber= viewModel.PhoneNumber;
            user.UserName= viewModel.UserName;
            user.Email= viewModel.Email;
            user.City= viewModel.City;

            if (viewModel.Photo!=null)
            {
                if (viewModel.PictureUrl!= "default_user.jpg")
                {
                    _imageHelper.Delete(viewModel.PictureUrl);
                }

                user.PictureUrl = await _imageHelper.ImageUpload(user.UserName, viewModel.Photo, viewModel.ImageTip.Value);

            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                _toast.AddErrorToastMessage();

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View(viewModel); 
            }

            await _userManager.UpdateSecurityStampAsync(user);

            return RedirectToAction(nameof(MemberController.UserProfile));

        }


        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View();

            }

            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var checkOldPassword = await _userManager.CheckPasswordAsync(user, viewModel.OldPassword);

            if (!checkOldPassword)
            {
                ModelState.AddModelError(string.Empty, "Şifreniz yanlıştır");
                return View();
            }

            var result = await _userManager.ChangePasswordAsync(user, viewModel.OldPassword, viewModel.ConfirmPassword);

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();

                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.PasswordSignInAsync(user, viewModel.ConfirmPassword, true, true);

                return RedirectToAction(nameof(MemberController.UserProfile));
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View();
        }






        #region Role

        public async Task<IActionResult> RoleList()
        {
            var roles = await _roleManager.Roles.Select(x => new RoleListViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();


            return View(roles);
        }

        public IActionResult RoleAdd()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleAdd(RoleAddViewModel viewModel)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Name = viewModel.Name });

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();
                return RedirectToAction(nameof(MemberController.RoleList));
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View();
        }

        public async Task<IActionResult> RoleUpdate(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var viewModel = new RoleUpdateViewModel()
            {
                Id = role.Id,
                Name = role.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel viewModel)
        {

            var role = await _roleManager.FindByIdAsync(viewModel.Id);

            role.Name = viewModel.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();

                return RedirectToAction(nameof(MemberController.RoleList));
            }

            _toast.AddErrorToastMessage();
            return View();

        }


        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();

            }

            _toast.AddErrorToastMessage();

            return RedirectToAction(nameof(MemberController.RoleList));


        }



        #endregion




    }
}
