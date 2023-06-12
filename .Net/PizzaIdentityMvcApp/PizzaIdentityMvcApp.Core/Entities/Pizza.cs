using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIdentityMvcApp.Core.Entities
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CreatedBy { get; set; } = "undefined";

        public DateTime CreatedDate { get; set;} = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }


    }
}
