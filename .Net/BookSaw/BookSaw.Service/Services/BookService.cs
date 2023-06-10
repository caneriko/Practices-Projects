using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.Repositories;
using BookSaw.Core.Services;
using BookSaw.Core.UnitOfWorks;
using BookSaw.Core.ViewModels.Book;
using BookSaw.Core.ViewModels.Category;
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
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<Book> _validator;
        private readonly IImageHelper _imageHelper;
        public BookService(IBookRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<Book> validator, IImageHelper imageHelper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _imageHelper = imageHelper;
        }

        public async Task AddAsync(BookAddViewModel viewModel)
        {
            if (viewModel.Photo!=null)
            {
                viewModel.PictureUrl = await _imageHelper.ImageUpload(viewModel.Name, viewModel.Photo, viewModel.ImageType);
            }

            var entity = _mapper.Map<Book>(viewModel);

           await _repository.AddAsync(entity);

           await _unitOfWork.CommitAsync();
        }  

        public Task<IEnumerable<BookAddViewModel>> AddRangeAsync(IEnumerable<BookAddViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookListViewModel>> GetAllAsync()
        {
            var entities = await _repository.GetAll(x => x.IsDeleted == false, x => x.Category!, x => x.Writer!).ToListAsync();

            var viewModel = _mapper.Map<List<BookListViewModel>>(entities);

            return viewModel;
        }

        public async Task<BookViewModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var viewModel = _mapper.Map<BookViewModel>(entity);

            return viewModel;
        }

        public async Task<BookUpdateViewModel> GetUpdateViewModelAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var viewModel = _mapper.Map<BookUpdateViewModel>(entity);

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

        public async Task UpdateAsync(BookUpdateViewModel viewModel)
        {
            var entity = await _repository.GetByIdAsync(viewModel.Id);

            entity = _mapper.Map(viewModel, entity);

            if (viewModel.Photo != null)
            {
                if (viewModel.PictureUrl != "default_book_image.jpg")
                {
                    _imageHelper.Delete(viewModel.PictureUrl);
                }
                entity.PictureUrl = await _imageHelper.ImageUpload(entity.Name, viewModel.Photo, viewModel.ImageType);

            }

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();

        }

        public IQueryable<BookViewModel> Where()
        {
            throw new NotImplementedException();
        }


        public async Task SafeDeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            entity.IsDeleted = true;

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();

        }


        public async Task<ValidationResult> ValidateUpdateModelAsync(BookUpdateViewModel viewModel)
        {
            var entity = _mapper.Map<Book>(viewModel);

            var validation = await _validator.ValidateAsync(entity);

            return validation;


        }

        public async Task<ValidationResult> ValidateAddModelAsync(BookAddViewModel viewModel)
        {
            var entity = _mapper.Map<Book>(viewModel);

            var validation = await _validator.ValidateAsync(entity);

            return validation;


        }


    }
}
