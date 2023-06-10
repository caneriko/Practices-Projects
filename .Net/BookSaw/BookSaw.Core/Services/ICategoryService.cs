using BookSaw.Core.ViewModels.Category;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorySaw.Core.Services
{
    public interface ICategoryService
    {
        Task<CategoryViewModel> GetByIdAsync(int id);
        Task<IEnumerable<CategoryListViewModel>> GetAllAsync();
        IQueryable<CategoryViewModel> Where();
        Task<bool> AnyAsync();

        Task AddAsync(CategoryAddViewModel viewModel);

        Task<IEnumerable<CategoryAddViewModel>> AddRangeAsync(IEnumerable<CategoryAddViewModel> viewModels);

        Task UpdateAsync(CategoryUpdateViewModel viewModel);

        Task RemoveAsync();

        Task RemoveRangeAsync();

        Task<List<CategoryViewModel>> GetAllViewModelsAsync();

        Task<CategoryUpdateViewModel> GetUpdateViewModelAsync(int id);

        Task<ValidationResult> ValidateUpdateModelAsync(CategoryUpdateViewModel viewModel);

        Task SafeDeleteAsync(int id);

        Task<ValidationResult> ValidateAddModelAsync(CategoryAddViewModel viewModel);
    }
}
