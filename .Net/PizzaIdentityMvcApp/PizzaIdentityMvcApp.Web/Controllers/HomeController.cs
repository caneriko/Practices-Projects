using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PizzaIdentityMvcApp.Core.Entities;
using PizzaIdentityMvcApp.Core.ViewModels.User;
using PizzaIdentityMvcApp.Web.Models;
using System.Diagnostics;

namespace PizzaIdentityMvcApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IToastNotification _toast;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IToastNotification toast, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _toast = toast;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignUpViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userManager.CreateAsync(new()
            {
                UserName=viewModel.UserName,
                FullName=viewModel.FullName,
                Email=viewModel.Email,
                PhoneNumber=viewModel.PhoneNumber
            }, viewModel.ConfirmPassword);

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();
                return RedirectToAction(nameof(HomeController.Index));
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();

            var viewModel = new List<UserListViewModel>();

            foreach (var item in users)
            {
                viewModel.Add(new() { Id=item.Id, Email = item.Email, FullName = item.FullName, UserName = item.UserName });

            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel viewModel, string returnUrl=null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var user = await _userManager.FindByEmailAsync(viewModel.Email);

            if (user==null)
            {
                ModelState.AddModelError(string.Empty, "Email yada şifre yanlış");
                return View();

            }


            var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, true);

            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "5 dakika boyunca giriş yapamazsınız");
                return Redirect(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "Email yada şifre yanlış");

            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}