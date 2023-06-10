using BookSaw.Core.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.Category
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public List<BookListViewModel> Books { get; set; } 
    }
}
