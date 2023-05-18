using MyBlog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.ViewModels.Articles
{
    public class ArticleAddViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid CategoryId { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
