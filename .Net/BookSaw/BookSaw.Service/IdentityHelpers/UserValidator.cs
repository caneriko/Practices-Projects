using BookSaw.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.IdentityHelpers
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {

            var errors = new List<IdentityError>();

            var isDigit = int.TryParse(user.UserName[0].ToString(), out _);

            if (isDigit)
            {
                errors.Add(new IdentityError() { Code = "UserNameStartsWithDigit", Description = "Username can not start with a digit" });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);

        }
    }
}
