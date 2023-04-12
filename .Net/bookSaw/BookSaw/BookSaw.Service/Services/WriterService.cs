using BookSaw.Core.Models;
using BookSaw.Core.Repositories;
using BookSaw.Core.Services;
using BookSaw.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.Services
{
    public class WriterService : Service<Writer>, IWriterService
    {
        public WriterService(IGenericRepository<Writer> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }



    }
}
