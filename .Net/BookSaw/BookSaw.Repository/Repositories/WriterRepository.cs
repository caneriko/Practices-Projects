using BookSaw.Core.Entities;
using BookSaw.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Repository.Repositories
{
    public class WriterRepository : GenericRepository<Writer>, IWriterRepository
    {
        public WriterRepository(BookSawDbContext context) : base(context)
        {
        }
    }
}
