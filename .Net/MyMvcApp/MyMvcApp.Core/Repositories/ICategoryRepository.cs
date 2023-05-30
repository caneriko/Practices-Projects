using MyMvcApp.Core.Entities;

namespace MyMvcApp.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProductsAsync(int CategoryId);
    }
}
