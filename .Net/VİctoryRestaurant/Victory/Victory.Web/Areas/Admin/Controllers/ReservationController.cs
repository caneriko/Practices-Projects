using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.ViewModels;
using Victory.Core.ViewModels.Contact;
using Victory.Core.ViewModels.Reservation;
using Victory.Service.Extensions;
using Victory.Service.Services;
using Victory.Service.ToastrMessages;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IValidator<Reservation> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;

        public ReservationController(IReservationService reservationService, IValidator<Reservation> validator, IMapper mapper, IToastNotification toast)
        {
            _reservationService = reservationService;
            _validator = validator;
            _mapper = mapper;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            var viewModels = await _reservationService.GetAllActiveReservationsAsync();
            return View(viewModels);
        }


        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Add(AddReservationViewModel viewModel)
        {
            var entity = _mapper.Map<Reservation>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Reservation.Add(), new ToastrOptions { Title = "Başarılı" });

                await _reservationService.AddAsync(viewModel);
                return RedirectToAction("index", "reservation", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);



            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var viewModel = await _reservationService.GetByIdAsync(id);

            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> Update(UpdateReservationViewModel viewModel)
        {

            var entity = _mapper.Map<Reservation>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Reservation.Update(viewModel.FullName), new ToastrOptions { Title = "Başarılı" });

                await _reservationService.UpdateAsync(viewModel);
                return RedirectToAction("index", "reservation", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);

            return View(viewModel);
        }


        public async Task<IActionResult> SafeDelete(int id)
        {
            await _reservationService.SafeDeleteAsync(id);
            _toast.AddSuccessToastMessage(ResultMessage.Reservation.Delete(), new ToastrOptions { Title = "Başarılı" });

            return RedirectToAction("Index", "reservation", new { Area = "Admin" });
        }


    }
}
