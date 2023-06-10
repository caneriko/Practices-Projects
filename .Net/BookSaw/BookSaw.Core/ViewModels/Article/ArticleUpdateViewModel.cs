using BookSaw.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.Article
{
    public class ArticleUpdateViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IFormFile? Photo { get; set; }

        public string? CreatedBy { get; set; }

        public string? PictureUrl { get; set; }

        public ImageType ImageType { get; set; } = ImageType.Article;
    }
}
