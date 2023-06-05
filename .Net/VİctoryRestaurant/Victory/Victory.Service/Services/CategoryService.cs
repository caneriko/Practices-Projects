using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.UnitOfWork;
using Victory.Core.ViewModels.Category;
using Victory.Service.Extensions;

namespace Victory.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
        }


        public async Task<List<CategoryListViewModel>> GetAllActiveCategoriesAsync()
        {
            var entities = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsActive == true);

            var map = _mapper.Map<List<CategoryListViewModel>>(entities);

            return map;
        }



        public async Task<UpdateCategoryViewModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);

            var map = _mapper.Map<UpdateCategoryViewModel>(entity);

            return map;
        }

        public async Task UpdateAsync(UpdateCategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);

            await _unitOfWork.GetRepository<Category>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();
        }


        public async Task AddAsync(AddCategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);

            entity.CreatedBy = _user.GetLoggedInUserName();

            await _unitOfWork.GetRepository<Category>().AddAsync(entity);

            await _unitOfWork.SaveAsync();
        }


        public async Task SafeDeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);

            entity.IsActive = false;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();

        }
    }
}
