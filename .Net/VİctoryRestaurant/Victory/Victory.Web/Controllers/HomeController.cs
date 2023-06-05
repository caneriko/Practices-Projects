using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Victory.Core.Services;
using Victory.Core.ViewModels;
using Victory.Core.ViewModels.Contact;
using Victory.Core.ViewModels.SigUp;
using Victory.Web.Models;

namespace Victory.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISignUpService _signUpService;
        private readonly IContactService _contactService;
        private readonly IReservationService _reservationService;

        public HomeController(ILogger<HomeController> logger, ISignUpService signUpService, IContactService contactService, IReservationService reservationService)
        {
            _logger = logger;
            _signUpService = signUpService;
            _contactService = contactService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Contact(AddContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _contactService.AddAsync(viewModel);
                return RedirectToAction("index", "home");
            }

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddSignUp(AddSignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _signUpService.AddAsync(viewModel);
                return RedirectToAction("index", "home");
            }

            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> AddReservation(AddReservationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _reservationService.AddAsync(viewModel);
                return RedirectToAction("index", "home");
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}