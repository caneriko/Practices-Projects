using ArticleSaw.Core.Services;
using BookSaw.Core.ViewModels.Article;
using BookSaw.Core.ViewModels.Book;
using BookSaw.Service.Messages;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookSaw.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IToastNotification _toast;


        public ArticleController(IArticleService articleService, IToastNotification toast)
        {
            _articleService = articleService;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _articleService.GetAllAsync();

            return View(viewModel);
        }


        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var viewModel = await _articleService.GetUpdateViewModelAsync(id);

            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Update(ArticleUpdateViewModel viewModel)
        {
            var validation = await _articleService.ValidateUpdateModelAsync(viewModel);

            if (validation.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Article.Update(viewModel.Title));

                await _articleService.UpdateAsync(viewModel);

                return RedirectToAction("index", "article", new { Area = "Admin" });

            }

            return View(viewModel);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> SafeDelete(int id)
        {
            await _articleService.SafeDeleteAsync(id);

            _toast.AddSuccessToastMessage("");

            return RedirectToAction("index", "book", new { Area = "Admin" });

        }

    }
}
