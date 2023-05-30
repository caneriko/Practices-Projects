using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.Repository;

namespace Victory.Core.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase,  new();

        Task<int> SaveAsync();

        int Save();
    }
}
