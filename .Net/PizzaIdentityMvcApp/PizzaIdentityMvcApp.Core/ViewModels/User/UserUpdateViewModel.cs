using Microsoft.AspNetCore.Http;
using PizzaIdentityMvcApp.Core.Enums;
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
        public string Id { get; set; } = null!;

        [Display(Name = "İsim Soyisim")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
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

        public IFormFile? Photo { get; set; }

        public string? PictureUrl { get; set; }

        public string? City { get; set; }

        public ImageType? ImageTip { get; set; } = ImageType.User;


    }
}
