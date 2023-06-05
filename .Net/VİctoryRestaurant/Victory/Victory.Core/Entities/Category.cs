using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.Entities
{
    public class Category : EntityBase
    {

        public string Name { get; set; }

        public string CreatedBy { get; set; } = "Undefined";

        public ICollection<Product> Products { get; set; }


    }
}
