using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleViewModel>> GetAllArticlesWithCategoryNonDeletedAsync();

        Task CreateArticleAsync(ArticleAddViewModel articleAddViewModel);

        Task<ArticleViewModel> GetArticleWithCategoryNonDeletedAsync(Guid id);

        Task<string> UpdateArticleAsync(ArticleUpdateViewModel articleUpdate);

        Task<string> SafeDeleteArticleAsync(Guid id);
    }
}
