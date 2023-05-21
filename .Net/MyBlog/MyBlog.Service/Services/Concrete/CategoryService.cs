using AutoMapper;
using Microsoft.AspNetCore.Http;
using MyBlog.Data.UnitOfWorks;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Categories;
using MyBlog.Service.Extensions;
using MyBlog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _user = _contextAccessor.HttpContext.User;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted == false);

            var map = _mapper.Map<List<CategoryViewModel>>(categories);

            return map;
        } 

        public async Task CreateCategoryAsync(CategoryAddViewModel categoryAddViewModel)
        {
            
            var userEmail = _user.GetLoggedInUserEmail();

            Category category = new(categoryAddViewModel.Name, userEmail);

            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.SaveAsync();

             
        }

        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            return category;
        }


        public async Task<string> UpdateCategoryAsync(CategoryUpdateViewModel categoryUpdate)
        {
            var userEmail = _user.GetLoggedInUserEmail();

            var category = await _unitOfWork.GetRepository<Category>().GetAsync(x=>!x.IsDeleted && x.Id == categoryUpdate.Id);

            category.Name = categoryUpdate.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return category.Name;

            
        }

        public async Task<string> SafeDeleteCategoryAsync(Guid id)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);

            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return category.Name;
        }
    }
}
