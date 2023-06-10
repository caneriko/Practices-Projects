using BookSaw.Core.ViewModels.Writer;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriterSaw.Core.Services
{
    public interface IWriterService
    {
        Task<WriterViewModel> GetByIdAsync(int id);
        Task<IEnumerable<WriterListViewModel>> GetAllAsync();
        IQueryable<WriterViewModel> Where();
        Task<bool> AnyAsync();

        Task AddAsync(WriterAddViewModel viewModel);

        Task<IEnumerable<WriterAddViewModel>> AddRangeAsync(IEnumerable<WriterAddViewModel> viewModels);

        Task UpdateAsync(WriterUpdateViewModel viewModel);

        Task RemoveAsync();

        Task RemoveRangeAsync();

        Task<List<WriterViewModel>> GetAllViewModelsAsync();

        Task<WriterUpdateViewModel> GetUpdateViewModelAsync(int id);

        Task<ValidationResult> ValidateEntityAsync(WriterUpdateViewModel viewModel);

        Task SafeDeleteAsync(int id);

        Task<ValidationResult> ValidateAddModelAsync(WriterAddViewModel viewModel);

    }
}
