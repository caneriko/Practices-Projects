﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Entities
{
    public class Writer : EntityBase
    {
        public string FullName { get; set; }

        public string Country { get; set; }

        public ICollection<Book> Books { get; set; }


    }
}
