using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.ViewModels.Article;

namespace Victory.Core.Services
{
    public interface IArticleService
    {
        Task<List<ArticleListViewModel>> GetAllActiveArticlesAsync();

        Task<UpdateArticleViewModel> GetByIdAsync(int id);

        Task UpdateAsync(UpdateArticleViewModel viewModel);

        Task AddAsync(AddArticleViewModel viewModel);

        Task SafeDeleteAsync(int id);


    }
}
