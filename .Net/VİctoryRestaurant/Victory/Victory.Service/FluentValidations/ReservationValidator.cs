using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;

namespace Victory.Service.FluentValidations
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.FullName).MaximumLength(20).MinimumLength(5).NotEmpty();
            RuleFor(x => x.NumberOfPersons).NotEmpty().InclusiveBetween(1, 6);
            RuleFor(x => x.PhoneNumber).MaximumLength(15).NotEmpty();
            RuleFor(x => x.ReservationDate).NotEmpty();
            
        }

    }
}
