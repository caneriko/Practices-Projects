using BookSaw.Core.Entities;
using BookSaw.Core.ViewModels.Book;
using BookSaw.Core.ViewModels.Writer;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Services
{
    public  interface IBookService  
    {

        Task<BookViewModel> GetByIdAsync(int id);
        Task<IEnumerable<BookListViewModel>> GetAllAsync();
        IQueryable<BookViewModel> Where();
        Task<bool> AnyAsync();

        Task AddAsync(BookAddViewModel viewModel);

        Task<IEnumerable<BookAddViewModel>> AddRangeAsync(IEnumerable<BookAddViewModel> viewModels);

        Task UpdateAsync(BookUpdateViewModel viewModel);

        Task RemoveAsync();

        Task RemoveRangeAsync();

        Task<BookUpdateViewModel> GetUpdateViewModelAsync(int id);

        Task SafeDeleteAsync(int id);

        Task<ValidationResult> ValidateUpdateModelAsync(BookUpdateViewModel viewModel);

        Task<ValidationResult> ValidateAddModelAsync(BookAddViewModel viewModel);

    }
}
