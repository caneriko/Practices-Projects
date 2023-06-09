﻿using Microsoft.AspNetCore.Http;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.ViewModels.Articles
{
    public class ArticleUpdateViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid CategoryId { get; set; }

        public Image Image { get; set; }

        public IFormFile? Photo { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
