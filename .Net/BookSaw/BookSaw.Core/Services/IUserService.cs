using BookSaw.Core.Entities;
using BookSaw.Core.ViewModels.User;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Services
{
    public interface IUserService
    {
        Task<IdentityResult> SignUp(UserSignUpViewModel viewModel);

        Task<List<UserListViewModel>> GetAllAsync();

        Task<UserProfileViewModel> GetUserProfileAsync(string userName);

        Task<bool> CheckPasswordAsync(string userName, UserChangePasswordViewModel viewModel);

        Task<IdentityResult> ChangePasswordAsync(string userName, UserChangePasswordViewModel viewModel);

        Task<UserUpdateViewModel> GetUserUpdateModelAsync(string userName);

        Task<IdentityResult> UpdateUserAsync(UserUpdateViewModel viewModel);

        Task<AppUser> GetAppUserByIdAsync(int Id);


     }
}
