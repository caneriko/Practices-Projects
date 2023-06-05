using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Enums;

namespace Victory.Core.ViewModels.User
{
    public class UpdateUserViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid RoleId { get; set; }

        public IFormFile? Photo { get; set; }

        public string? PictureUrl { get; set; }

        public ImageType ImageType { get; set; } = ImageType.User;



    }
}
