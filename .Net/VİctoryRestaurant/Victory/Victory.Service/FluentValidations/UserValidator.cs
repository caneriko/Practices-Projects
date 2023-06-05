﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;

namespace Victory.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(50);


            RuleFor(x => x.LastName)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(50);

            RuleFor(x => x.PhoneNumber)
             .NotEmpty()
             .MinimumLength(11);
              
        }
    }
}
