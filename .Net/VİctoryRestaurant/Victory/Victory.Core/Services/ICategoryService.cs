using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.ViewModels.Category;

namespace Victory.Core.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryListViewModel>> GetAllActiveCategoriesAsync();

        Task<UpdateCategoryViewModel> GetByIdAsync(int id);

        Task UpdateAsync(UpdateCategoryViewModel viewModel);

        Task AddAsync(AddCategoryViewModel viewModel);

        Task SafeDeleteAsync(int id);
    }
}
