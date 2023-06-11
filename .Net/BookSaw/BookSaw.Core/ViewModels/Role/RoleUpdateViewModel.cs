using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.Role
{
    public class RoleUpdateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
