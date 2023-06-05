using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.ViewModels.Article
{
    public class ArticleBlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string? PictureUrl { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
