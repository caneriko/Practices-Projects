using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.ViewModels.SigUp;
using Victory.Service.Extensions;
using Victory.Service.ToastrMessages;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SignupController : Controller
    {
        private readonly ISignUpService _signUpService;
        private readonly IMapper _mapper;
        private readonly IValidator<Signup> _validator;
        private readonly IToastNotification _toast;

        public SignupController(ISignUpService signUpService, IMapper mapper, IValidator<Signup> validator, IToastNotification toast)
        {
            _signUpService = signUpService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var signUpModels = await _signUpService.GetAllActiveSignUps();

            return View(signUpModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSignUpViewModel viewModel)
        {
            var entity = _mapper.Map<Signup>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Signup.Add(), new ToastrOptions { Title = "Başarılı" });

                await _signUpService.AddAsync(viewModel);
                return RedirectToAction("index", "signup", new {Area="Admin"});
            }

            result.AddToModelState(this.ModelState);

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var signUpModels = await _signUpService.GetByIdAsync(id);

            return View(signUpModels);
        }

        [HttpPost]

        public async Task<IActionResult> Update(UpdateSignUpViewModel viewModel)
        {

            var entity = _mapper.Map<Signup>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Signup.Update(), new ToastrOptions { Title = "Başarılı" });

                await _signUpService.UpdateAsync(viewModel);
                return RedirectToAction("index", "signup", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);

            return View(viewModel);
        }

        
        public async Task<IActionResult> SafeDelete(int id)
        {

            await _signUpService.SafeDeleteAsync(id);
            _toast.AddSuccessToastMessage(ResultMessage.Signup.Delete(), new ToastrOptions { Title = "Başarılı" });

            return RedirectToAction("Index", "signup", new { Area = "Admin" });

        }


    }
}
