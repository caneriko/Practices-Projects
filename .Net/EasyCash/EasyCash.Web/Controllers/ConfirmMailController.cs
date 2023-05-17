using EasyCash.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Web.Controllers
{
	public class ConfirmMailController : Controller
	{
		[HttpGet]
		public IActionResult Index(int id)
		{

			return View();
		}

        [HttpPost]
        public IActionResult Index(ConfirmMailViewModel confirmMailViewModel )
        {
            return View();
        }
    }
}
