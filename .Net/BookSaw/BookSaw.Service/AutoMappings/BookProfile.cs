using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.AutoMappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book,BookAddViewModel>().ReverseMap();
            CreateMap<Book,BookViewModel>().ReverseMap();
            CreateMap<Book,BookUpdateViewModel>().ReverseMap();
            CreateMap<Book,BookListViewModel>().ReverseMap();
        }

    }
}
