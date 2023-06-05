using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.ViewModels.Contact;

namespace Victory.Service.Mapping
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactListViewModel>().ReverseMap();
            CreateMap<Contact, UpdateContactViewModel>().ReverseMap();
            CreateMap<Contact, AddContactViewModel>().ReverseMap();
        }
    }
}
