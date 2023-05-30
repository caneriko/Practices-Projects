using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.Entities
{
    public class Reservation : EntityBase
    {
        public string FullName { get; set; }

        public DateTime ReservationDate { get; set; }

        public string PhoneNumber { get; set; }

        public int NumberOfPersons { get; set; }

 

    }
}
