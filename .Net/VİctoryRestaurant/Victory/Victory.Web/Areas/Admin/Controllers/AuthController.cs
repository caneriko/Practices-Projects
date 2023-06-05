using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Victory.Core.Entities;
using Victory.Core.ViewModels.User;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
         
        public async Task<IActionResult> Login(UserLoginViewModel userModel)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userModel.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userModel.Password, userModel.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email or password is wrong");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is wrong");
                    return View();
                }
            }

            return View();




        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

    }
}
