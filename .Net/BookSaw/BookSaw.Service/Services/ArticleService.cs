using ArticleSaw.Core.Services;
using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.Repositories;
using BookSaw.Core.UnitOfWorks;
using BookSaw.Core.ViewModels.Article;
using BookSaw.Core.ViewModels.Book;
using BookSaw.Service.Helpers;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;
        private readonly IImageHelper _imageHelper;

        public ArticleService(IArticleRepository articleRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<Article> validator, IImageHelper imageHelper)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _imageHelper = imageHelper;
        }

        public Task AddAsync(ArticleAddViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleAddViewModel>> AddRangeAsync(IEnumerable<ArticleAddViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArticleListViewModel>> GetAllAsync()
        {
            var entities =  await _articleRepository.GetAll().ToListAsync();

            var viewModel = _mapper.Map<List<ArticleListViewModel>>(entities);

            return viewModel;
        }

        public Task<ArticleViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleUpdateViewModel> GetUpdateViewModelAsync(int id)
        {
            var entity = await _articleRepository.GetByIdAsync(id);

            var viewModel = _mapper.Map<ArticleUpdateViewModel>(entity);

            return viewModel;
        }

        public Task RemoveAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ArticleUpdateViewModel viewModel)
        {
            var entity = await _articleRepository.GetByIdAsync(viewModel.Id);

            entity = _mapper.Map(viewModel, entity);

            if (viewModel.Photo != null)
            {
                if (viewModel.PictureUrl != "default_book_image.jpg")
                {
                    _imageHelper.Delete(viewModel.PictureUrl);
                }
                entity.PictureUrl = await _imageHelper.ImageUpload(entity.Title, viewModel.Photo, viewModel.ImageType);

            }

            _articleRepository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<ArticleViewModel> Where()
        {
            throw new NotImplementedException();
        }

        public async Task SafeDeleteAsync(int id)
        {
            var entity = await _articleRepository.GetByIdAsync(id);
            entity.IsDeleted = true;

            _articleRepository.Update(entity);
            await _unitOfWork.CommitAsync();

        }

        public async Task<ValidationResult> ValidateUpdateModelAsync(ArticleUpdateViewModel viewModel)
        {
            var entity = _mapper.Map<Article>(viewModel);

            var validation = await _validator.ValidateAsync(entity);

            return validation;


        }
    }
}
