using BookSaw.Core.ViewModels.Category;
using BookSaw.Service.Extensions;
using BookSaw.Service.Messages;
using CategorySaw.Core.Services;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookSaw.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toast;


        public CategoryController(ICategoryService categoryService, IToastNotification toast)
        {
            _categoryService = categoryService;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _categoryService.GetAllAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var viewModel = await _categoryService.GetUpdateViewModelAsync(id);

            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Update(CategoryUpdateViewModel viewModel)
        {
            var validation = await _categoryService.ValidateUpdateModelAsync(viewModel);

            if (validation.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Category.Update(viewModel.Name));

              await  _categoryService.UpdateAsync(viewModel);

                return RedirectToAction("index", "category", new { Area = "Admin" });
            }

            validation.AddToModelState(this.ModelState);
            return View(viewModel);

        }

        public async Task<IActionResult> SafeDelete(int id)
        {
            await _categoryService.SafeDeleteAsync(id);

            _toast.AddSuccessToastMessage("");

            return RedirectToAction("index", "category", new { Area = "Admin" });


        }


        [HttpPost]

        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddViewModel viewModel)
        {
            var validation = await _categoryService.ValidateAddModelAsync(viewModel);

            if (validation.IsValid)
            {
                await _categoryService.AddAsync(viewModel);

                _toast.AddSuccessToastMessage(ResultMessage.Category.Add(viewModel.Name));

                return Json(ResultMessage.Category.Add(viewModel.Name));
            }
            else
            {
                _toast.AddErrorToastMessage(validation.Errors.First().ErrorMessage);

                return Json(validation.Errors.First().ErrorMessage);
            }



        }

    }
}
