using Microsoft.AspNetCore.Identity;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("E8F4D0B0-6EEB-4BC2-8080-0FCF3A1C12D3");

        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }

    }
}
