using MyBlog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategoriesNonDeleted();
    }
}
