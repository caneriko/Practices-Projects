using Microsoft.EntityFrameworkCore;
using MyMvcApp.Core.Entities;
using MyMvcApp.Core.Repositories;

namespace MyMvcApp.Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
