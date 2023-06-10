using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.Article
{
    public class ArticleListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CreatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
