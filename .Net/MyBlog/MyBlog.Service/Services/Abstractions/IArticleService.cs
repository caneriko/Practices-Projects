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

        Task<List<ArticleViewModel>> GetAllDeletedArticlesWithCategoryAsync();


        Task CreateArticleAsync(ArticleAddViewModel articleAddViewModel);

        Task<ArticleViewModel> GetArticleWithCategoryNonDeletedAsync(Guid id);

        Task<string> UpdateArticleAsync(ArticleUpdateViewModel articleUpdate);

        Task<string> SafeDeleteArticleAsync(Guid id);
        Task<string> UndoDeleteArticleAsync(Guid id);

        Task<ArticleListViewModel> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);


        Task<ArticleListViewModel> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);


    }
}
