using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
