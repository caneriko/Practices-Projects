using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Enums;

namespace Victory.Core.ViewModels.Article
{
    public class UpdateArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public IFormFile? Photo { get; set; }

        public string? PictureUrl { get; set; }

        public ImageType ImageType { get; set; } = 0;

    }
}
