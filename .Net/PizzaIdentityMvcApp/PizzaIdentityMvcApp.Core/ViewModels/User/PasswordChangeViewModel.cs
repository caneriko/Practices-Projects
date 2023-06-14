using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaIdentityMvcApp.Core.ViewModels.User
{
    public class PasswordChangeViewModel
    {
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string OldPassword { get; set; }

        [MinLength(6, ErrorMessage = "Şifre En az 6 karakter olmalıdır")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string NewPassword { get; set; }

        [Display(Name = "Şifre Onay")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler aynı değil")]

        public string ConfirmPassword { get; set; }
    }


}
