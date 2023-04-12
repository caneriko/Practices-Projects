using BookSaw.Core.Models;
using BookSaw.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookSawDbContext context) : base(context)
        {

        }
    }
}
