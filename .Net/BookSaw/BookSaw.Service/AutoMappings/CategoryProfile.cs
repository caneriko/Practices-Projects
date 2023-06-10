using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorySaw.Service.AutoMappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryAddViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, CategoryUpdateViewModel>().ReverseMap();
            CreateMap<Category, CategoryListViewModel>().ReverseMap();
        }

    }
}
