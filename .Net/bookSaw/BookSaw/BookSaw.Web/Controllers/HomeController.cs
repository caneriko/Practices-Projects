using AutoMapper;
using BookSaw.Core.Models;
using BookSaw.Core.Services;
using BookSaw.Core.ViewModels;
using BookSaw.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookSaw.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookService _service;

        private readonly UserManager<AppUser> _userManager;

        public HomeController(IMapper mapper, IBookService service, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _service = service;
            _userManager = userManager;
        }

        #region entityServices  

        public async Task<IActionResult> Index()
        {

            return View(await _service.GetBooksWithCategory());
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        #endregion

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignUp(SignUpModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


           var result = await _userManager.CreateAsync(new()
            {
                UserName=request.UserName,
                PhoneNumber=request.Phone,
                Email=request.Email
                
            }, request.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Üyelik kayıt işlemi başarıyla gerçekleşmiştir";

                return RedirectToAction(nameof(HomeController.SignUp));
            }


            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View();
        }



        #region Identity




        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}