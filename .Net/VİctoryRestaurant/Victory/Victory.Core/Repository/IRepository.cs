using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.Repository
{
    public interface IRepository<T> where  T : class
    {
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includeProperties);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, Object>>[] includeProperties);


        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);



    }
}
