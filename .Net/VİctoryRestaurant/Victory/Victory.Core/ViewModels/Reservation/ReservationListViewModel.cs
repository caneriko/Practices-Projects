using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.ViewModels.Reservation
{
    public class ReservationListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public DateTime ReservationDate { get; set; }

        public string PhoneNumber { get; set; }

        public int NumberOfPersons { get; set; }

        public bool IsActive { get; set; }


    }
}
