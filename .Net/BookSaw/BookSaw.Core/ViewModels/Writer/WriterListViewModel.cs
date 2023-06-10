using BookSaw.Core.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.Writer
{
    public class WriterListViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Country { get; set; }

        public bool IsDeleted { get; set; }

        public List<BookListViewModel> Books { get; set; }
    }
}
