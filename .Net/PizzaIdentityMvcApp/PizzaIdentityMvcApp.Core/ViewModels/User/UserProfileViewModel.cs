using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaIdentityMvcApp.Core.ViewModels.User
{
    public class UserProfileViewModel
    {

         
        public string FullName { get; set; }


        public string UserName { get; set; }
 

        public string Email { get; set; }
 

        public string PhoneNumber { get; set; }

        public string? City { get; set; }

        public string? PictureUrl { get; set; }

    }
}
