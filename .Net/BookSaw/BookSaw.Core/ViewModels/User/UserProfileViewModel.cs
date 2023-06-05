﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.User
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }

        public string PictureUrl { get; set; }
    }
}
