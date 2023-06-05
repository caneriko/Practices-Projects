using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.ViewModels;
using Victory.Core.ViewModels.Reservation;

namespace Victory.Service.Mapping
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, AddReservationViewModel>().ReverseMap();
            CreateMap<Reservation, ReservationListViewModel>().ReverseMap();
            CreateMap<Reservation, UpdateReservationViewModel>().ReverseMap();
        }
    }
}
