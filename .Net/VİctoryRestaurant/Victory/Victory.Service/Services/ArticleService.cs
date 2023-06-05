using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.UnitOfWork;
using Victory.Core.ViewModels.Article;
using Victory.Service.Helpers.ImageHelper;

namespace Victory.Service.Services
{
    public class ArticleService : IArticleService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageHelper = imageHelper;
        }


        public async Task<List<ArticleListViewModel>> GetAllActiveArticlesAsync()
        {
            var entities = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsActive == true);

            var map = _mapper.Map<List<ArticleListViewModel>>(entities);

            return map;
        }



        public async Task<UpdateArticleViewModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Article>().GetByIdAsync(id);

            var map = _mapper.Map<UpdateArticleViewModel>(entity);

            return map;
        }

        public async Task UpdateAsync(UpdateArticleViewModel viewModel)
        {

            if (viewModel.Photo!=null)
            {
                _imageHelper.Delete(viewModel.PictureUrl);

                viewModel.PictureUrl = await _imageHelper.ImageUpload(viewModel.Title, viewModel.Photo, viewModel.ImageType);

            }

            var entity = _mapper.Map<Article>(viewModel);


            await _unitOfWork.GetRepository<Article>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();
        }


        public async Task AddAsync(AddArticleViewModel viewModel)
        {
            var entity = _mapper.Map<Article>(viewModel);

            entity.PictureUrl = await _imageHelper.ImageUpload(entity.Title, viewModel.Photo, viewModel.ImageType);

            await _unitOfWork.GetRepository<Article>().AddAsync(entity); 

            await _unitOfWork.SaveAsync();
        } 


        public async Task SafeDeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Article>().GetByIdAsync(id);

            entity.IsActive = false;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();

        }


        public async Task<List<ArticleBlogViewModel>> GetBlogArticlesAsync()
        {
            var entities = await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>x.IsActive==true);

            var map = _mapper.Map<List<ArticleBlogViewModel>>(entities);

            return map;

        }


    }
}
