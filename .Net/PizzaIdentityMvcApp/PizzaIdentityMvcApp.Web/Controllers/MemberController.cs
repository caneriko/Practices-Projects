using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaIdentityMvcApp.Core.Entities;

namespace PizzaIdentityMvcApp.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public MemberController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Deneme()
        {
            return View();
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
                
        }
    }
}
