using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.ViewModels.SigUp;

namespace Victory.Service.FluentValidations
{
    public class SignUpModelValidator : AbstractValidator<SignUpViewModel>
    {
        public SignUpModelValidator()
        {
            
        }
    }
}
