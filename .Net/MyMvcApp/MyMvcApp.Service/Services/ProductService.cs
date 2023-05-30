using AutoMapper;
using MyMvcApp.Core.DTOs;
using MyMvcApp.Core.Entities;
using MyMvcApp.Core.Repositories;
using MyMvcApp.Core.Services;
using MyMvcApp.Core.UnitOfWorks;

namespace MyMvcApp.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategory()
        {
            var product = await _productRepository.GetProductsWithCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(product);

            return productsDto;
        }
    }
}
