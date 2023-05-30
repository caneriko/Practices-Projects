using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.ViewModels.SigUp
{
    public class SignUpViewModel
    {
        public string Email { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsActive { get; set; }

    }
}
