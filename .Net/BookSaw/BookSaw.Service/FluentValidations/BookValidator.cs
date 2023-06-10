using BookSaw.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.FluentValidations
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.PublishDate).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.WriterId).NotEmpty();

        }

    }
}
