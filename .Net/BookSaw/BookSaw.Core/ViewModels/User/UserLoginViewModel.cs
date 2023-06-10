using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.User
{
    public class UserLoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage ="You need to enter Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="You need to enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
