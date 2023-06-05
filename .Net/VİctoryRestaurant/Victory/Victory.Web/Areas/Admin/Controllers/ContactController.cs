using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.ViewModels.Contact;
using Victory.Service.Extensions;
using Victory.Service.Services;
using Victory.Service.ToastrMessages;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly IValidator<Contact> _validator;
        private readonly IToastNotification _toast;


        public ContactController(IContactService contactService, IMapper mapper, IValidator<Contact> validator, IToastNotification toast)
        {
            _contactService = contactService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var contactModels = await _contactService.GetAllActiveContactsAsync();

            return View(contactModels);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var viewModel = await _contactService.GetByIdAsync(id);

            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> Update(UpdateContactViewModel viewModel)
        {

            var entity = _mapper.Map<Contact>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Contact.Update(), new ToastrOptions { Title = "Başarılı" });

                await _contactService.UpdateAsync(viewModel);
                return RedirectToAction("index", "Contact", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);

            return View(viewModel);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddContactViewModel viewModel)
        {
            var entity = _mapper.Map<Contact>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Contact.Add(), new ToastrOptions { Title = "Başarılı" });

                await _contactService.AddAsync(viewModel);
                return RedirectToAction("index", "contact", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);

            return View(viewModel);
        }


        public async Task<IActionResult> SafeDelete(int id)
        {
            await _contactService.SafeDeleteAsync(id);
            _toast.AddSuccessToastMessage(ResultMessage.Contact.Delete(), new ToastrOptions { Title = "Başarılı" });

            return RedirectToAction("Index", "contact", new { Area = "Admin" });
        }

    }
}
