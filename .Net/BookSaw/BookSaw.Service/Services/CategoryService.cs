using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.Repositories;
using BookSaw.Core.UnitOfWorks;
using BookSaw.Core.ViewModels.Book;
using BookSaw.Core.ViewModels.Category;
using BookSaw.Repository.Repositories;
using CategorySaw.Core.Services;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _validator;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<Category> validator)
        {
            _repository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task AddAsync(CategoryAddViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);

           await  _repository.AddAsync(entity);

            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<CategoryAddViewModel>> AddRangeAsync(IEnumerable<CategoryAddViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryListViewModel>> GetAllAsync()
        {
            var entities = await _repository.GetAll(x=>x.IsDeleted==false, x=>x.Books)
                .ToListAsync();

            var viewModel = _mapper.Map<List<CategoryListViewModel>>(entities);

            return viewModel;
        }


        public async Task<List<CategoryViewModel>> GetAllViewModelsAsync()
        {
            var entities = await _repository.GetAll().ToListAsync();

            var viewModel = _mapper.Map<List<CategoryViewModel>>(entities);

            return viewModel;
        }

        public Task<CategoryViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CategoryUpdateViewModel viewModel)
        {
            var entity = await _repository.GetByIdAsync(viewModel.Id);

            entity = _mapper.Map(viewModel, entity);

            _repository.Update(entity);
           await  _unitOfWork.CommitAsync();
        }

        public IQueryable<CategoryViewModel> Where()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryUpdateViewModel> GetUpdateViewModelAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var viewModel = _mapper.Map<CategoryUpdateViewModel>(entity);

            return viewModel;
        }

        public async Task<ValidationResult> ValidateUpdateModelAsync(CategoryUpdateViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);

            var validation = await _validator.ValidateAsync(entity);

            return validation;
            

        }

        public Task<ValidationResult> ValidateAddModelAsync(CategoryAddViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);

            var validation = _validator.ValidateAsync(entity);

            return validation;
        }

        public async Task SafeDeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            entity.IsDeleted = true;

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();

        }

    }
}
