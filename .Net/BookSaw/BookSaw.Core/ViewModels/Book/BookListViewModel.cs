using BookSaw.Core.ViewModels.Category;
using BookSaw.Core.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.Book
{
    public class BookListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsDeleted { get; set; }

        public CategoryViewModel? Category { get; set; }

        public WriterViewModel? Writer { get; set; }
    }
}
