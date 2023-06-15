﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIdentityMvcApp.Core.Entities
{
    public class AppUser : IdentityUser 
    {
        public string FullName { get; set; }

        public string? City { get; set; }

        public string PictureUrl { get; set; } = "default_user.jpg";


    }
}
