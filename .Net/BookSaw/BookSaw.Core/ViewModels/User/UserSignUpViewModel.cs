using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.User
{
    public class UserSignUpViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        
        public string Password { get; set; }

        [Compare(nameof(Password),ErrorMessage ="Passwords do not match")]
        public string RePassword { get; set; }

    }
}
