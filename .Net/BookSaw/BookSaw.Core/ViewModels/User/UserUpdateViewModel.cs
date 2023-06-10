using BookSaw.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.User
{
    public class UserUpdateViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string? PictureUrl { get; set; }

        public IFormFile? Photo { get; set; }

        public DateTime? Birthday { get; set; }

        public string? City { get; set; }

        public ImageType ImageType { get; set; } = ImageType.User;


    }
}
