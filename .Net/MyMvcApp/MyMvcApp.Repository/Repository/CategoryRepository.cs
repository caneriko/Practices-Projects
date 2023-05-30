using Microsoft.EntityFrameworkCore;
using MyMvcApp.Core.Entities;
using MyMvcApp.Core.Repositories;

namespace MyMvcApp.Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int CategoryId)
        {
            return await _context.Categories.Include(x => x.Products).Where(x => x.Id == CategoryId).SingleOrDefaultAsync();
        }
    }
}
