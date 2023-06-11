using BookSaw.Core.ViewModels.Writer;
using BookSaw.Service.Extensions;
using BookSaw.Service.FluentValidations;
using BookSaw.Service.Messages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Data;
using WriterSaw.Core.Services;

namespace BookSaw.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]

    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly IToastNotification _toast;


        public WriterController(IWriterService writerService, IToastNotification toast)
        {
            _writerService = writerService;
            _toast = toast;
        }

        [Authorize(Roles = "SuperAdmin, Admin, User")]

        public async Task<IActionResult> Index()
        {
            var viewModel = await _writerService.GetAllAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var viewModel = await _writerService.GetUpdateViewModelAsync(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WriterUpdateViewModel viewModel)
        {

            var validation = await _writerService.ValidateEntityAsync(viewModel);

            if (validation.IsValid)
            {

                await _writerService.UpdateAsync(viewModel);
                _toast.AddSuccessToastMessage(ResultMessage.Writer.Update(viewModel.FullName));

                return RedirectToAction("index", "writer", new { Area = "Admin" });

            }

            validation.AddToModelState(this.ModelState);
            return View(viewModel);
        }

        public async Task<IActionResult> SafeDelete(int id)
        {
           await _writerService.SafeDeleteAsync(id);

            _toast.AddSuccessToastMessage("");

            return RedirectToAction("index", "writer", new { Area = "Admin" });


        }


        [HttpPost]

        public async Task<IActionResult> AddWithAjax([FromBody] WriterAddViewModel viewModel)
        {
            var validation = await _writerService.ValidateAddModelAsync(viewModel);

            if (validation.IsValid)
            {
                await _writerService.AddAsync(viewModel);

                _toast.AddSuccessToastMessage(ResultMessage.Writer.Add(viewModel.FullName));

                return Json(ResultMessage.Writer.Add(viewModel.FullName));
            }
            else
            {
                _toast.AddErrorToastMessage(validation.Errors.First().ErrorMessage);

                return Json(validation.Errors.First().ErrorMessage);
            }



        }



    }
}
