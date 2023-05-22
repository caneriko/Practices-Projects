using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        private readonly DataContext _context;

        public PizzaController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.Pizzas.ToListAsync());
        } 
    }
}
