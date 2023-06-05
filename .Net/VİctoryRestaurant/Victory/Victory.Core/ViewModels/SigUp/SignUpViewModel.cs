﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.ViewModels.SigUp
{
    public class SignUpViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

    }
}
