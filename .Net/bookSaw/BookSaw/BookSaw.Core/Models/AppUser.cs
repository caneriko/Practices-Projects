using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public ICollection<Article>? Articles { get; set; } 


    }
}
