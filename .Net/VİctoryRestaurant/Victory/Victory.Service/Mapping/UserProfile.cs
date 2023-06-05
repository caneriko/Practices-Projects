using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.ViewModels.User;

namespace Victory.Service.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<AppUser, UserListViewModel>().ReverseMap();
            CreateMap<AppUser, UpdateUserViewModel>().ReverseMap();
            CreateMap<AppUser, AddUserViewModel>().ReverseMap();
            CreateMap<AppUser, UserProfileViewModel>().ReverseMap();
        }
    }
}
