using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Data.Context;
using MyBlog.Data.Repositories.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new() 
    {
        protected readonly MyBlogDbContext _context;
        private readonly DbSet<T> _dbSet;

         

        public Repository(MyBlogDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _dbSet.CountAsync(predicate);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _dbSet.Remove(entity));

        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, Object>>[] includeProperties )
        {
            IQueryable<T> query = _dbSet;

            if (predicate!=null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }

            }

            return await query.ToListAsync();

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate  , params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(predicate);

            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }

            }

            return await query.SingleAsync();



        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
            return entity;
        }
    }
}
