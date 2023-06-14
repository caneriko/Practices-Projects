using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaIdentityMvcApp.Core.ViewModels.User
{
    public class UserUpdateViewModel
    {
        public string Id { get; set; }

        [Display(Name = "İsim Soyisim")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string FullName { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]


        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [EmailAddress]

        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]

        public string PhoneNumber { get; set; }



    }
}
