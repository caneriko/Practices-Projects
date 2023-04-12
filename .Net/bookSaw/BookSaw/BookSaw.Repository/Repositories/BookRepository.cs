using BookSaw.Core.Models;
using BookSaw.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Repository.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookSawDbContext context) : base(context)
        {
        }

        public async Task<List<Book>> GetBooksWithCategory()
        {
            return await _context.Books.Include(x => x.Category).ToListAsync();
        }
    }
}
