using EmployeeApp.Core.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Service.Validations
{
    public class EmployeeViewModelValidator : AbstractValidator<EmployeeViewModel>
    {

        public EmployeeViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            //RuleFor(x => x.Salary).InclusiveBetween(1, int.MaxValue).NotEmpty().WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.DepartmentId).InclusiveBetween(1, int.MaxValue).NotEmpty().WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
