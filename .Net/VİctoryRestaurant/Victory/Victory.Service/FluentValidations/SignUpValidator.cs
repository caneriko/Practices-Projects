using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;

namespace Victory.Service.FluentValidations
{
    public class SignUpValidator : AbstractValidator<Signup>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            
        }
    }
}
