using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Articles;
using MyBlog.Service.Services.Abstractions;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
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
            await _articleService.CreateArticleAsync(model);

            RedirectToAction("Index", "Article", new { Area = "Admin" });

            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddViewModel { Categories = categories });

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


            await _articleService.UpdateArticleAsync(articleUpdateModel);

            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            articleUpdateModel.Categories = categories;

            return View(articleUpdateModel);


        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _articleService.SafeDeleteArticleAsync(id);

            return RedirectToAction("Index","Article", new {Area="Admin"});
        }
    }
}
