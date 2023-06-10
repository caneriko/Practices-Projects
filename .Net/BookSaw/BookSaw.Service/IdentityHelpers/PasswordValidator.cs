using BookSaw.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.IdentityHelpers
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {

            
                var errors = new List<IdentityError>();


                if (password!.ToLower().Contains(user.UserName.ToLower()))
                {
                    errors.Add(new() { Code = "PasswordCantContainUserName", Description = "Password can not contain username" });
                }

                if (password!.ToLower().Contains("1234"))
                {
                    errors.Add(new() { Code = "PasswordCantContain1234", Description = "Password can not contain 4 successive digits" });

                }

                if (errors.Any())
                {
                    return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
                }

                return Task.FromResult(IdentityResult.Success);
 

        }
    }
}
