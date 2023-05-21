using AutoMapper;
using Microsoft.AspNetCore.Http;
using MyBlog.Data.UnitOfWorks;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Enums;
using MyBlog.Entity.ViewModels.Articles;
using MyBlog.Service.Extensions;
using MyBlog.Service.Helpers.Images;
using MyBlog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ClaimsPrincipal _user;

        private readonly IImageHelper _ımageHelper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor,  IImageHelper ımageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext!.User;
            _ımageHelper = ımageHelper;
        }

        public async Task CreateArticleAsync(ArticleAddViewModel articleAddViewModel)
        {
            //var userId = Guid.Parse("967B3995-B6F0-4C09-97F9-C5AC3D9D7A02");

            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInUserEmail();

            //var imageId = Guid.Parse("3435C2A1-305D-4105-9BBC-9F7327686546");

            var imageUpload = await _ımageHelper.Upload(articleAddViewModel.Title, articleAddViewModel.Photo, ImageType.Post);

            Image image = new(imageUpload.FullName, articleAddViewModel.Photo.ContentType, userEmail);

            await _unitOfWork.GetRepository<Image>().AddAsync(image);



            var article = new Article(articleAddViewModel.Title, articleAddViewModel.Content,userId,articleAddViewModel.CategoryId, image.Id ,userEmail);

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
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id==id, x => x.Category, i =>i.Image);

            var map = _mapper.Map<ArticleViewModel>(article);

            return map;

        }


        public async Task<string> UpdateArticleAsync(ArticleUpdateViewModel articleUpdate)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleUpdate.Id, x => x.Category, i=> i.Image);

            var userEmail = _user.GetLoggedInUserEmail();

            if (articleUpdate.Photo!= null)
            {
                _ımageHelper.Delete(article.Image.FileName);

                var imageupload = await _ımageHelper.Upload(articleUpdate.Title, articleUpdate.Photo, ImageType.Post);

                Image image = new(imageupload.FullName, articleUpdate.Photo.ContentType, userEmail);

                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                article.ImageId=image.Id;
            }

            article.Title = articleUpdate.Title;
            article.Content = articleUpdate.Content;
            article.CategoryId = articleUpdate.CategoryId;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<string> SafeDeleteArticleAsync(Guid id)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetByIdAsync(id);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy=userEmail;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return article.Title;
        }
    }
}
