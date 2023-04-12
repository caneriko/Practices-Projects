using AutoMapper;
using BookSaw.Core.Models;
using BookSaw.Core.Repositories;
using BookSaw.Core.Services;
using BookSaw.Core.UnitOfWorks;
using BookSaw.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService 
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
    }
}
