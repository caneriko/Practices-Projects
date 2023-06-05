using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.ViewModels;
using Victory.Core.ViewModels.Contact;
using Victory.Core.ViewModels.Reservation;

namespace Victory.Core.Services
{
    public interface IReservationService
    {
        Task AddAsync(AddReservationViewModel viewModel);

        Task<List<ReservationListViewModel>> GetAllActiveReservationsAsync();

        Task<UpdateReservationViewModel> GetByIdAsync(int id);

        Task UpdateAsync(UpdateReservationViewModel viewModel);

        Task SafeDeleteAsync(int id);
    }
}
