using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.Repositories;
using BookSaw.Core.UnitOfWorks;
using BookSaw.Core.ViewModels.Category;
using BookSaw.Core.ViewModels.Writer;
using BookSaw.Service.FluentValidations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterSaw.Core.Services;

namespace BookSaw.Service.Services
{
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<Writer> _validator;


        public WriterService(IWriterRepository writerRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<Writer> validator)
        {
            _writerRepository = writerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task AddAsync(WriterAddViewModel viewModel)
        {
            var entity = _mapper.Map<Writer>(viewModel);

            await _writerRepository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

        }

        public Task<IEnumerable<WriterAddViewModel>> AddRangeAsync(IEnumerable<WriterAddViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WriterListViewModel>> GetAllAsync()
        {
            var entities = await _writerRepository.GetAll(x => x.IsDeleted == false, x => x.Books).ToListAsync();

            var viewModel = _mapper.Map<List<WriterListViewModel>>(entities);

            return viewModel;
        }

        public async Task<List<WriterViewModel>> GetAllViewModelsAsync()
        {
            var entities = await _writerRepository.GetAll().ToListAsync();

            var viewModel = _mapper.Map<List<WriterViewModel>>(entities);

            return viewModel;
        }

        public async Task<WriterUpdateViewModel> GetUpdateViewModelAsync(int id)
        {
            var entity = await _writerRepository.GetByIdAsync(id);

            var viewModel = _mapper.Map<WriterUpdateViewModel>(entity);

            return viewModel;
        }

        public Task<WriterViewModel> GetByIdAsync(int id)
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

        public async Task UpdateAsync(WriterUpdateViewModel viewModel)
        {
            var entity = await _writerRepository.GetByIdAsync(viewModel.Id);

            entity = _mapper.Map(viewModel, entity);

            _writerRepository.Update(entity);

            await _unitOfWork.CommitAsync();
        }

        public IQueryable<WriterViewModel> Where()
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> ValidateEntityAsync(WriterUpdateViewModel viewModel)
        {
            var entity = _mapper.Map<Writer>(viewModel);

            var validation = await _validator.ValidateAsync(entity);

            return validation;
        }

        public async Task SafeDeleteAsync(int id)
        {
            var entity = await _writerRepository.GetByIdAsync(id);

            entity.IsDeleted = true;

            _writerRepository.Update(entity);
            await _unitOfWork.CommitAsync();

        }

        public Task<ValidationResult> ValidateAddModelAsync(WriterAddViewModel viewModel)
        {
            var entity = _mapper.Map<Writer>(viewModel);

            var validation = _validator.ValidateAsync(entity);

            return validation;
        }

    }
}
