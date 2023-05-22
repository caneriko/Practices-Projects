using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Categories;
using MyBlog.Service.Extensions;
using MyBlog.Service.Services.Abstractions;
using MyBlog.Web.ResultMessages;
using NToastNotify;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IValidator<Category> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;

        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IToastNotification toast, IMapper mapper)
        {
            _categoryService = categoryService;
            _validator = validator;
            _toast = toast;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            return View(categories);
        }

        public async Task<IActionResult> DeletedCategories()
        {
            var categories = await _categoryService.GetAllCategoriesDeleted();

            return View(categories);
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddViewModel categoryAddViewModel)
        {
            var map = _mapper.Map<Category>(categoryAddViewModel);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddViewModel);

                _toast.AddSuccessToastMessage(Message.Category.Add(categoryAddViewModel.Name), new ToastrOptions { Title = "İşlem Başarılı" });

                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddViewModel categoryAddViewModel)
        {
            var map = _mapper.Map<Category>(categoryAddViewModel);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddViewModel);

                _toast.AddSuccessToastMessage(Message.Category.Add(categoryAddViewModel.Name), new ToastrOptions { Title = "İşlem Başarılı" });

                return Json(Message.Category.Add(categoryAddViewModel.Name));
            }
            else
            {
                _toast.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });

                return Json(result.Errors.First().ErrorMessage);
            }

            

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var category = await _categoryService.GetCategoryByGuid(id);
            var map = _mapper.Map<CategoryUpdateViewModel>(category);

            return View(map);
        }

        [HttpPost]

        public async Task<IActionResult> Update(CategoryUpdateViewModel categoryUpdate)
        {
            var map = _mapper.Map<Category>(categoryUpdate);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await _categoryService.UpdateCategoryAsync(categoryUpdate);
                _toast.AddSuccessToastMessage(Message.Category.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });

                return RedirectToAction("Index", "Category", new { Area = "Admin" });

            }

            result.AddToModelState(this.ModelState);
            return View();

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var name = await _categoryService.SafeDeleteCategoryAsync(id);
            _toast.AddSuccessToastMessage(Message.Article.Delete(name), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        public async Task<IActionResult> UndoDelete(Guid id)
        {
            var name = await _categoryService.UndoDeleteCategoryAsync(id);
            _toast.AddSuccessToastMessage(Message.Article.UndoDelete(name), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

    }
}
