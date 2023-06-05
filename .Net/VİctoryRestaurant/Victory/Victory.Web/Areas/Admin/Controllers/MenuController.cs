using Microsoft.AspNetCore.Mvc;
using Victory.Core.Services;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IActionResult> Index()
        {
            var menuModel = await _menuService.GetMenuAsync();

            return View(menuModel);
        }
    }
}
