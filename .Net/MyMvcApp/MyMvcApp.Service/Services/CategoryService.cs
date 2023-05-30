using AutoMapper;
using MyMvcApp.Core.DTOs;
using MyMvcApp.Core.Entities;
using MyMvcApp.Core.Repositories;
using MyMvcApp.Core.Services;
using MyMvcApp.Core.UnitOfWorks;

namespace MyMvcApp.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        
    }
}
