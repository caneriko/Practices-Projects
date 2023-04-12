using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels
{
    public class SignUpModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage ="Girilen şifreler uyuşmamaktadır.")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [Display(Name = "Şifre Tekrar")]
        public string PasswordConfirm { get; set; }
    }
}
