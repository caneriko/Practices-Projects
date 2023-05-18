using AutoMapper;
using MyBlog.Data.UnitOfWorks;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Articles;
using MyBlog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateArticleAsync(ArticleAddViewModel articleAddViewModel)
        {
            var userId = Guid.Parse("967B3995-B6F0-4C09-97F9-C5AC3D9D7A02");
            var imageId = Guid.Parse("3435C2A1-305D-4105-9BBC-9F7327686546");

            var article = new Article(articleAddViewModel.Title, articleAddViewModel.Content,userId,articleAddViewModel.CategoryId,imageId);

            //var article = new Article
            //{
            //    Title = articleAddViewModel.Title,
            //    Content = articleAddViewModel.Content,
            //    CategoryId = articleAddViewModel.CategoryId,
            //    UserId = userId,
            //};

            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleViewModel>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>x.IsDeleted==false, x=>x.Category);

            var map = _mapper.Map<List<ArticleViewModel>>(articles);

            return map;

        }

        public async Task<ArticleViewModel> GetArticleWithCategoryNonDeletedAsync(Guid id)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id==id, x => x.Category);

            var map = _mapper.Map<ArticleViewModel>(article);

            return map;

        }


        public async Task UpdateArticleAsync(ArticleUpdateViewModel articleUpdate)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleUpdate.Id, x => x.Category);

            article.Title = articleUpdate.Title;
            article.Content = articleUpdate.Content;
            article.CategoryId = articleUpdate.CategoryId;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteArticleAsync(Guid id)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetByIdAsync(id);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }
    }
}
