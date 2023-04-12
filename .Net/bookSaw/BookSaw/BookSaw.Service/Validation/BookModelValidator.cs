using BookSaw.Core.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.Validation
{
    public class BookModelValidator : AbstractValidator<BookModel>
    {
        public BookModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("İsim boş bırakılamaz").NotEmpty().WithMessage("İsim boş bırakılamaz");

            RuleFor(x=>x.Price).InclusiveBetween(1,int.MaxValue)
                .NotEmpty().WithMessage("Fiyat alanı boş ve sıfır olamaz");

            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue)
               .NotEmpty().WithMessage("Kategori boş bırakılamaz");

            RuleFor(x => x.WriterId).InclusiveBetween(1, int.MaxValue)
               .NotEmpty().WithMessage("Yazar seçilmelidir");


        }
    }
}
