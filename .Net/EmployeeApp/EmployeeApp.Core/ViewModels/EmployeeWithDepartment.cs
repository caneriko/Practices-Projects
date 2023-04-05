﻿using EmployeeApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Core.ViewModels
{
    public class EmployeeWithDepartment : EmployeeViewModel
    {
        public Department Department { get; set; }
    }
}
