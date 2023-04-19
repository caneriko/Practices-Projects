using BookSaw.Core.Models;
using BookSaw.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookSaw.Web.Controllers
{
    [Authorize] 
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public MemberController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult>  Index()
        {

            var currentUser =await  _userManager.FindByNameAsync(User.Identity!.Name);

            var userModel = new UserModel() 
            {
                Email = currentUser.Email,
                UserName = currentUser.UserName, 
                PhoneNumber = currentUser.PhoneNumber 
            };

            return View(userModel);
        }

        public async Task<IActionResult> Logout()
        {
          
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
