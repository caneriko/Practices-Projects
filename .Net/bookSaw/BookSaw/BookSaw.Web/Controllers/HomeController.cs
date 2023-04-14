using AutoMapper;
using BookSaw.Core.Models;
using BookSaw.Core.Services;
using BookSaw.Core.ViewModels;
using BookSaw.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookSaw.Web.Extensions;

namespace BookSaw.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookService _service;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly UserManager<AppUser> _userManager;

        public HomeController(IMapper mapper, IBookService service, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _service = service;
            _userManager = userManager;
            _signInManager = signInManager;
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




        #region Identity

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
                UserName = request.UserName,
                PhoneNumber = request.Phone,
                Email = request.Email

            }, request.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Üyelik kayıt işlemi başarıyla gerçekleşmiştir";

                return RedirectToAction(nameof(HomeController.SignUp));
            }


            ModelState.AddModelErrorList(result.Errors.Select(x=>x.Description).ToList());

            //foreach (var item in result.Errors)
            //{
            //    ModelState.AddModelError(string.Empty, item.Description);
            //}

            return View();
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel request, string? returnUrl=null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user==null)
            {
                ModelState.AddModelError(string.Empty, "Bu email adresiyla kayıtlı kullanıcı bulunmamaktadır");
                return View();
            }



            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);

            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelErrorList(new List<string>() { "3 dakika boyunca giriş yapamazsınız" });
                    return View();

                }

                if (await _userManager.GetAccessFailedCountAsync(user) < 3)
                {
                    ModelState.AddModelErrorList(new List<string>() { $" Hatalı giriş, Kalan giriş hakkı {3 - await _userManager.GetAccessFailedCountAsync(user)} " });
                }


            } 


            return View();
        }


        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}