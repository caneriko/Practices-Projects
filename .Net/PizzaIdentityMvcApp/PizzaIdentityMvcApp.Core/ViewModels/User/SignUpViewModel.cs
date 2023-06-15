using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIdentityMvcApp.Core.ViewModels.User
{
    public class SignUpViewModel
    {
        [Display(Name ="İsim Soyisim")]
        [Required(ErrorMessage ="Bu alan boş geçilemez")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]


        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [EmailAddress]

        public string Email { get; set; } = null!;

        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]


        public string PhoneNumber { get; set; } = null!;


        [Required(ErrorMessage = "Bu alan boş geçilemez")]


        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "ŞifreOnay")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Compare(nameof(Password),ErrorMessage ="Şifreler aynı değil")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; } = null!;
    }
}
