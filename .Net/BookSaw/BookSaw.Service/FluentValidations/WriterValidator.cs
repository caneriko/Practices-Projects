using BookSaw.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.FluentValidations
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Country).NotEmpty();
        }


    }
}
