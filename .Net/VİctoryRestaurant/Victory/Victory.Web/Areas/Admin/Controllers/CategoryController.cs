using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.ViewModels.Category;
using Victory.Service.Extensions;
using Victory.Service.Services;
using Victory.Service.ToastrMessages;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _validator;
        private readonly IToastNotification _toast;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<Category> validator, IToastNotification toast)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return RedirectToAction("Index", "menu", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var viewModel = await _categoryService.GetByIdAsync(id);

            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> Update(UpdateCategoryViewModel viewModel)
        {

            var entity = _mapper.Map<Category>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Category.Update(viewModel.Name), new ToastrOptions { Title = "Başarılı" });

                await _categoryService.UpdateAsync(viewModel);
                return RedirectToAction("index", "category", new { Area = "Admin" });
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

        public async Task<IActionResult> Add(AddCategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Category.Add(viewModel.Name), new ToastrOptions { Title = "Başarılı" });
                await _categoryService.AddAsync(viewModel);
                return RedirectToAction("index", "category", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);

            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> AddWithAjax([FromBody] AddCategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Category.Add(viewModel.Name), new ToastrOptions { Title = "Başarılı" });
                await _categoryService.AddAsync(viewModel);
                return Json(ResultMessage.Category.Add(viewModel.Name));
            }
            else
            {
                _toast.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }
            
        }


        public async Task<IActionResult> SafeDelete(int id)
        {
            await _categoryService.SafeDeleteAsync(id);
            var viewModel = await _categoryService.GetByIdAsync(id);
            _toast.AddSuccessToastMessage(ResultMessage.Category.Add(viewModel.Name), new ToastrOptions { Title = "Başarılı" });

            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }





    }
}

