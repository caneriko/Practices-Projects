﻿using Microsoft.AspNetCore.Mvc;
using MyBlog.Service.Services.Abstractions;
using MyBlog.Web.Models;
using System.Diagnostics;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage=1, int pageSize=3, bool isAscending=false)
        {


            var articles = await _articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);

            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {


            var articles = await _articleService.SearchAsync( keyword, currentPage, pageSize, isAscending);

            return View(articles);
        }


        public async Task<IActionResult> Detail(Guid id) 
        {
            var article = await _articleService.GetArticleWithCategoryNonDeletedAsync(id);
            return View(article);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}