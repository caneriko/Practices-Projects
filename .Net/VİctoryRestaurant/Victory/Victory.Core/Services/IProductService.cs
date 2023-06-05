using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.ViewModels.Product;

namespace Victory.Core.Services
{
    public interface IProductService
    {
        Task<List<ProductListViewModel>> GetAllActiveProductsAsync();

        Task<UpdateProductViewModel> GetByIdAsync(int id);

        Task UpdateAsync(UpdateProductViewModel viewModel);

        Task AddAsync(AddProductViewModel viewModel);

        Task SafeDeleteAsync(int id);
    }
}
