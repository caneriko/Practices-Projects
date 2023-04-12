using BookSaw.Core.Models;
using BookSaw.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Services
{
    public interface IBookService : IService<Book>
    {
        Task<List<BookWithCategory>> GetBooksWithCategory();

    }
}
