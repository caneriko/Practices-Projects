using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;

namespace Victory.Service.FluentValidations
{
    public class ContactValidator :AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Message).MinimumLength(30).NotEmpty();
            RuleFor(x=>x.PhoneNumber).MaximumLength(15).NotEmpty();
            RuleFor(x=>x.Name).MinimumLength(5).MaximumLength(20).NotEmpty();
        }
    }
}
