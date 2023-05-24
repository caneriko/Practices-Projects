using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.ViewModels.Articles
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public CategoryViewModel Category { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public Image Image { get; set; }

        public string CreatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public AppUser User { get; set; }

        public int ViewCount { get; set; }



    }
}
