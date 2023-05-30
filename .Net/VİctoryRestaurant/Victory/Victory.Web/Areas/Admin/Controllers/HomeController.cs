using Microsoft.AspNetCore.Mvc;
using Victory.Core.Services;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ISignUpService _signUpService;

        public HomeController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        public async Task<IActionResult> Index()
        {
            var signUpModels = await _signUpService.GetAllActiveSignUps();

            return View(signUpModels);
        }
    }
}
