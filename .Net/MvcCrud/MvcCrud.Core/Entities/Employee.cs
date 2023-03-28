using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrud.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
