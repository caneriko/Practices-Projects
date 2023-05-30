using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Repository;
using Victory.Core.UnitOfWork;
using Victory.Repository.Repository;

namespace Victory.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VictoryDbContext _context;

        public UnitOfWork(VictoryDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public int Save()
        {
           return  _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
             return new Repository<T>(_context);
        }
    }
}
