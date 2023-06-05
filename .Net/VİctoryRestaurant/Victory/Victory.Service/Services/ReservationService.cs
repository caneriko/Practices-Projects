using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.UnitOfWork;
using Victory.Core.ViewModels;
using Victory.Core.ViewModels.Contact;
using Victory.Core.ViewModels.Reservation;

namespace Victory.Service.Services
{
    public class ReservationService : IReservationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet] 
        public async Task<List<ReservationListViewModel>> GetAllActiveReservationsAsync()
        {
            var entities = await _unitOfWork.GetRepository<Reservation>().GetAllAsync(x=>x.IsActive==true);
            var map = _mapper.Map<List<ReservationListViewModel>>(entities);
            return map;
        }


        public async Task AddAsync(AddReservationViewModel viewModel)
        {
            var entity = _mapper.Map<Reservation>(viewModel);

            await _unitOfWork.GetRepository<Reservation>().AddAsync(entity);

            await _unitOfWork.SaveAsync();
        }

        public async Task<UpdateReservationViewModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Reservation>().GetByIdAsync(id);

            var map = _mapper.Map<UpdateReservationViewModel>(entity);

            return map;
        }

        public async Task UpdateAsync(UpdateReservationViewModel viewModel)
        {
            var entity = _mapper.Map<Reservation>(viewModel);

            await _unitOfWork.GetRepository<Reservation>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Reservation>().GetByIdAsync(id);

            entity.IsActive = false;

            await _unitOfWork.GetRepository<Reservation>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();

        }

    }
}
