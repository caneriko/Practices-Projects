using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.User
{
    public class UserChangePasswordViewModel
    {

        [Required]
        public string OldPassword { get; set; }
        [Required]

        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
        [Required]

        public string ConfirmPassword { get; set; }

    }
}


