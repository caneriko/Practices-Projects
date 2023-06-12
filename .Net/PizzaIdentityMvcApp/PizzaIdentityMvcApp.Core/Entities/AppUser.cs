﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIdentityMvcApp.Core.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }

        public string? City { get; set; }


    }
}
