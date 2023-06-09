﻿using BookSaw.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.FluentValidations
{
    public  class AppUserValidator : AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {
            RuleFor(x => x.FullName)
             .NotEmpty()
             .MinimumLength(5)
             .MaximumLength(50);

            RuleFor(x => x.UserName)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(50);

            RuleFor(x => x.Email)
            .NotEmpty()
            .MinimumLength(3)
            .EmailAddress();


            RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MinimumLength(9);
            












        }

         
           
          

    }
}
