using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.AutoMappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserListViewModel>();
            CreateMap<AppUser,UserAddViewModel>().ReverseMap();
            CreateMap<AppUser,UserUpdateViewModel>().ReverseMap();
            CreateMap<AppUser, UserProfileViewModel>();
            CreateMap<AppUser,UserSignUpViewModel>().ReverseMap();
        }
    }
}
