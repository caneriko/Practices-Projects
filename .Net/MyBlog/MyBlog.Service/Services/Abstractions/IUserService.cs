using Microsoft.AspNetCore.Identity;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddViewModel userAdd);
        Task<IdentityResult> UpdateUserAsync(UserUpdateViewModel userUpdate);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileViewModel> GetUserProfileAsync();
        Task<bool> UserProfileUpdateAsync(UserProfileViewModel userProfile);
    }
}
