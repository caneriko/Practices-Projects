using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIdentityMvcApp.Core.ViewModels.User
{
    public class UserLoginViewModel
    {


        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]

        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]

        public bool RememberMe { get; set; }
    }
}
