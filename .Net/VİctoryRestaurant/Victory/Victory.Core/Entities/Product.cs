﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

 

    }
}
