using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.UnitOfWork;
using Victory.Core.ViewModels.Product;

namespace Victory.Service.Services
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<ProductListViewModel>> GetAllActiveProductsAsync()
        {
            var entities = await _unitOfWork.GetRepository<Product>().GetAllAsync(x => x.IsActive == true);

            var map = _mapper.Map<List<ProductListViewModel>>(entities);

            return map;
        }


        public async Task<UpdateProductViewModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);

            var map = _mapper.Map<UpdateProductViewModel>(entity);

            return map;
        }

        public async Task UpdateAsync(UpdateProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            await _unitOfWork.GetRepository<Product>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();
        }


        public async Task AddAsync(AddProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            await _unitOfWork.GetRepository<Product>().AddAsync(entity);

            await _unitOfWork.SaveAsync();
        }


        public async Task SafeDeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);

            entity.IsActive = false;

            await _unitOfWork.GetRepository<Product>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();

        }

    }
}
