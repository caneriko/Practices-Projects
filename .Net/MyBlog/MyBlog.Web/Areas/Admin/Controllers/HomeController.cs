﻿using Microsoft.AspNetCore.Mvc;
using MyBlog.Service.Services.Abstractions;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;

        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesAsync();

            return View(articles);
        }
    }
}
