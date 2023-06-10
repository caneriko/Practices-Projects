
using BookSaw.Core.ViewModels.Article;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSaw.Core.Services
{
    public interface IArticleService
    {
        Task<ArticleViewModel> GetByIdAsync(int id);
        Task<IEnumerable<ArticleListViewModel>> GetAllAsync();
        IQueryable<ArticleViewModel> Where();
        Task<bool> AnyAsync();

        Task AddAsync(ArticleAddViewModel viewModel);

        Task<IEnumerable<ArticleAddViewModel>> AddRangeAsync(IEnumerable<ArticleAddViewModel> viewModels);

        Task UpdateAsync(ArticleUpdateViewModel viewModel);

        Task RemoveAsync();

        Task RemoveRangeAsync();

        Task<ArticleUpdateViewModel> GetUpdateViewModelAsync(int id);

        Task SafeDeleteAsync(int id);

        Task<ValidationResult> ValidateUpdateModelAsync(ArticleUpdateViewModel viewModel);


    }
}
