using AutoMapper;
using MyBlog.Data.UnitOfWorks;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Categories;
using MyBlog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted == false);

            var map = _mapper.Map<List<CategoryViewModel>>(categories);

            return map;
        }
    }
}
