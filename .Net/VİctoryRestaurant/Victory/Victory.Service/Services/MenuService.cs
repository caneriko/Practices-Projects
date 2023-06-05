using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.UnitOfWork;
using Victory.Core.ViewModels.Category;
using Victory.Core.ViewModels.Menu;
using Victory.Core.ViewModels.Product;

namespace Victory.Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper   _mapper;

        public MenuService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MenuViewModel> GetMenuAsync()
        {
            var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(x=>x.IsActive, x=>x.Category);

            var productsMap = _mapper.Map<List<ProductListViewModel>>(products);

            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsActive);

            var categoriesMap = _mapper.Map<List<CategoryListViewModel>>(categories);

            var menuModel = new MenuViewModel() { Categories=categoriesMap, Products= productsMap };

            return menuModel;

        }

    }
}
