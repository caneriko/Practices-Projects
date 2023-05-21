using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Articles;
using MyBlog.Service.Extensions;
using MyBlog.Service.Services.Abstractions;
using MyBlog.Web.ResultMessages;
using NToastNotify;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;
        private readonly IToastNotification _toastNotification;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toastNotification)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddViewModel { Categories=categories});
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddViewModel model)
        {
            var map = _mapper.Map<Article>(model);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _articleService.CreateArticleAsync(model);

                _toastNotification.AddSuccessToastMessage(Message.Article.Add(model.Title),  new ToastrOptions { Title="Başarılı!"});


               return RedirectToAction("Index", "Article", new { Area = "Admin" });
            } 
            else
            {
                result.AddToModelState(this.ModelState);

                var categories = await _categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddViewModel { Categories = categories });

            }

        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid id)
        {
            var article = await _articleService.GetArticleWithCategoryNonDeletedAsync(id);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            var articleUpdate = _mapper.Map<ArticleUpdateViewModel>(article);
            articleUpdate.Categories = categories;

            return View(articleUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateViewModel articleUpdateModel)
        {
            var map = _mapper.Map<Article>(articleUpdateModel);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
               var title=  await _articleService.UpdateArticleAsync(articleUpdateModel);
                _toastNotification.AddSuccessToastMessage(Message.Article.Update(title), new ToastrOptions { Title="Başarılı!"});

                return RedirectToAction("Index", "Article", new { Area = "Admin" });


            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            articleUpdateModel.Categories = categories;

            return View(articleUpdateModel);


        }

        public async Task<IActionResult> Delete(Guid id)
        {
           var title =  await _articleService.SafeDeleteArticleAsync(id);

            _toastNotification.AddSuccessToastMessage(Message.Article.Delete(title), new ToastrOptions { Title = "İşlem Başarılı!" });

            return RedirectToAction("Index","Article", new {Area="Admin"});
        }
    }
}
