using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.Services;
using BookSaw.Core.ViewModels.User;
using BookSaw.Service.Extensions;
using BookSaw.Service.Messages;
using BookSaw.Service.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookSaw.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IToastNotification _toast;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUser> _validator;


        public AdminController(IUserService userService, IToastNotification toast, IMapper mapper, IValidator<AppUser> validator)
        {
            _userService = userService;
            _toast = toast;
            _mapper = mapper;
            _validator = validator;
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

    }

}

