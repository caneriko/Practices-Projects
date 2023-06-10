using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.Services;
using BookSaw.Core.ViewModels.User;
using BookSaw.Service.Extensions;
using BookSaw.Service.Messages;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookSaw.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IValidator<AppUser> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;




        public AuthController(IUserService userService, IValidator<AppUser> validator, IMapper mapper, IToastNotification toast, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _validator = validator;
            _mapper = mapper;
            _toast = toast;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Signup(UserSignUpViewModel viewModel)
        {


            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<AppUser>(viewModel);

                var validation = await _validator.ValidateAsync(entity);

                if (validation.IsValid)
                {
                    var result = await _userService.SignUp(viewModel);

                    if (result.Succeeded)
                    {
                        _toast.AddSuccessToastMessage(ResultMessage.User.Signup(), new ToastrOptions { Title = "Başarılı İşlem" });
                        return RedirectToAction("Login", "Auth");
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

            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel viewModel, string? returnUrl)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);

                if (user != null)
                {

                    var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, user.LockoutEnabled);

                    if (result.Succeeded)
                    {
                        _toast.AddSuccessToastMessage(ResultMessage.User.Login(), new ToastrOptions { Title = "Başarılı İşlem" });


                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return RedirectToAction(returnUrl);
                        }

                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }

                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "You can't sign-in for 3 minutes");
                        return View();
                    }

                    ModelState.AddModelError(string.Empty, "Password or Email wrong");
 
                }

                ModelState.AddModelError(string.Empty, "Password or Email wrong");
            }


            return View();
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
