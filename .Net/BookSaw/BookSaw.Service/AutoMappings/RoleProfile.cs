using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.AutoMappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AppRole, RoleAddViewModel>().ReverseMap();
            CreateMap<AppRole, RoleListViewModel>().ReverseMap();
            CreateMap<AppRole, RoleUpdateViewModel>().ReverseMap();
        }

    }
}
