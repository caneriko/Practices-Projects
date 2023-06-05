using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.ViewModels.User;

namespace Victory.Core.Services
{
    public interface IUserService
    {
        Task<List<UserListViewModel>> GetUserListAsync();

        Task<List<AppRole>> GetRolesAsync();

        Task<IdentityResult> AddAsync(AddUserViewModel viewModel);

        Task<UpdateUserViewModel> GetUserByIdAsync(Guid id);

        Task<AppUser> GetAppUserByIdAsync(Guid Id);

        Task<string> GetUserRoleAsync(AppUser user);

        Task<(IdentityResult identityResult, string? userName)> DeleteAsync(Guid userId);
        Task<AppRole> GetUserRoleIdAsync(Guid id);
        Task<IdentityResult> UpdateAsync(UpdateUserViewModel viewModel);

        Task<UserProfileViewModel> ProfileAsync(string name);
    }
}
