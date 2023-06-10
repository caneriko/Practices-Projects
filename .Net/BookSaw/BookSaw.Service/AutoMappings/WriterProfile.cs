using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.AutoMappings
{
    public class WriterProfile : Profile
    {
        public WriterProfile()
        {
            CreateMap<Writer,WriterAddViewModel>().ReverseMap();
            CreateMap<Writer,WriterListViewModel>().ReverseMap();
            CreateMap<Writer,WriterUpdateViewModel>().ReverseMap();
            CreateMap<Writer,WriterViewModel>().ReverseMap();
        }
    }
}
