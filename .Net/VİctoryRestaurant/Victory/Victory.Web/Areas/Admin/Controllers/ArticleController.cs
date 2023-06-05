using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.ViewModels.Article;
using Victory.Service.Extensions;

using Victory.Service.Services;
using Victory.Service.ToastrMessages;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IToastNotification _toast;

        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;

        public ArticleController(IArticleService articleService, IMapper mapper, IValidator<Article> validator, IToastNotification toast)
        {
            _articleService = articleService;
            _mapper = mapper;
            _validator = validator;
            _toast = toast;
        }


        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var ArticleModels = await _articleService.GetAllActiveArticlesAsync();

            return View(ArticleModels);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var viewModel = await _articleService.GetByIdAsync(id);

            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> Update(UpdateArticleViewModel viewModel)
        {

            var entity = _mapper.Map<Article>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Article.Update(viewModel.Title), new ToastrOptions { Title = "Başarılı" });
                await _articleService.UpdateAsync(viewModel);
                return RedirectToAction("index", "Article", new { Area = "Admin" });
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

        public async Task<IActionResult> Add(AddArticleViewModel viewModel)
        {
            var entity = _mapper.Map<Article>(viewModel);
            var result = await _validator.ValidateAsync(entity);

            if (result.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Article.Add(viewModel.Title), new ToastrOptions { Title = "Başarılı" });

                await _articleService.AddAsync(viewModel);
                return RedirectToAction("index", "Article", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);

            return View(viewModel); 
        }


        public async Task<IActionResult> SafeDelete(int id)
        {
            await _articleService.SafeDeleteAsync(id);
            var entity = await _articleService.GetByIdAsync(id);
            _toast.AddSuccessToastMessage(ResultMessage.Article.Delete(entity.Title), new ToastrOptions { Title = "Başarılı" });

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }









    }
}
