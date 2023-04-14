using BookSaw.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.CustomValidator
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var errors = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower())) 
            {
                errors.Add(new IdentityError() { Code = "PasswordNoContainsUserName", Description = "Şifre alanı kullanıcı adı içeremez" });
            }

            if (password.StartsWith("1234"))
            {
                errors.Add(new() { Code = "PasswordNoContains1234", Description = "Şifre 1234 ile başlayamaz" });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);


        }
    }
}
