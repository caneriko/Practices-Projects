﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.EntityLayer.Concrete
{
    public class AccountProcess
    {
        public int Id { get; set; }

        public string ProcessType { get; set; }

        public decimal Amount { get; set; }

        public DateTime ProcessDate { get; set; }



    }
}
