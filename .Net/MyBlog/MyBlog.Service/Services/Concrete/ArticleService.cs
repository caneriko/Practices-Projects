using MyBlog.Data.UnitOfWorks;
using MyBlog.Entity.Entities;
using MyBlog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Article>> GetAllArticlesAsync()
        {
            return await _unitOfWork.GetRepository<Article>().GetAllAsync();
        }
    }
}
