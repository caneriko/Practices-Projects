using MyBlog.Entity.Entities;
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
        Task<List<CategoryViewModel>> GetAllCategoriesNonDeletedTake24();
        Task<List<CategoryViewModel>> GetAllCategoriesDeleted();

        Task CreateCategoryAsync(CategoryAddViewModel categoryAddViewModel);

        Task<Category> GetCategoryByGuid(Guid id);

        Task<string> UpdateCategoryAsync(CategoryUpdateViewModel categoryUpdate);

        Task<string> SafeDeleteCategoryAsync(Guid id);
        Task<string> UndoDeleteCategoryAsync(Guid id);


    }
}
