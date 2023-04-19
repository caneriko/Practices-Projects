using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookSaw.Core.ViewModels
{
    public class PasswordChangeModel
    {
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        [MinLength(6,ErrorMessage ="Şifre en az 6 karakter ")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare(nameof(NewPassword), ErrorMessage = "Girilen şifreler uyuşmamaktadır.")]

        public string ConfirmPassword { get; set; }
    }
}
