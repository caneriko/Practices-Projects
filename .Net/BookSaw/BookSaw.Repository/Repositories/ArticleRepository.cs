using BookSaw.Core.Entities;
using BookSaw.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Repository.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(BookSawDbContext context) : base(context)
        {

        }
    }
}
