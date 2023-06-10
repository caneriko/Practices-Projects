using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
