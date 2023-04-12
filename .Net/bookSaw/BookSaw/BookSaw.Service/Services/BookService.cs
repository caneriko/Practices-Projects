using AutoMapper;
using BookSaw.Core.Models;
using BookSaw.Core.Repositories;
using BookSaw.Core.Services;
using BookSaw.Core.UnitOfWorks;
using BookSaw.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.Services
{
    public class BookService : Service<Book>, IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public BookService(IGenericRepository<Book> repository, IUnitOfWork unitOfWork, IMapper mapper, IBookRepository bookRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<List<BookWithCategory>> GetBooksWithCategory()
        {
            var bookWithCategory = await _bookRepository.GetBooksWithCategory();

            return _mapper.Map<List<BookWithCategory>>(bookWithCategory);
        }
    }
}
