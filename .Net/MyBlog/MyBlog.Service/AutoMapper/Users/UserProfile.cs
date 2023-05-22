using AutoMapper;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser,UserViewModel>().ReverseMap();
            CreateMap<AppUser,UserAddViewModel>().ReverseMap();
        }
    }
}
