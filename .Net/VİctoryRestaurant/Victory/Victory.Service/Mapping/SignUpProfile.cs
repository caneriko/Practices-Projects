using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.ViewModels.SigUp;

namespace Victory.Service.Mapping
{
    public class SignUpProfile : Profile
    {
        public SignUpProfile()
        {
            CreateMap<Signup, SignUpViewModel>().ReverseMap();
            CreateMap<Signup,UpdateSignUpViewModel>().ReverseMap();
            CreateMap<Signup,AddSignUpViewModel>().ReverseMap();
        }
    }
}
