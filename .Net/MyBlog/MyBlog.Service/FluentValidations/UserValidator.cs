using FluentValidation;
using MyBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .MinimumLength(2).MaximumLength(150)
                .WithName("İsim");

            RuleFor(x => x.LastName).NotEmpty()
               .MinimumLength(2).MaximumLength(150)
               .WithName("Soyisim");

            RuleFor(x => x.PhoneNumber).NotEmpty()
               .MinimumLength(11)
               .WithName("Telefon Numarası");


        }
    }
}
