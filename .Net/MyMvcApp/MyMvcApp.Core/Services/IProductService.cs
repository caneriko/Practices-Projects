using MyMvcApp.Core.DTOs;
using MyMvcApp.Core.Entities;

namespace MyMvcApp.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCategoryDto>> GetProductsWithCategory();
    }
}
