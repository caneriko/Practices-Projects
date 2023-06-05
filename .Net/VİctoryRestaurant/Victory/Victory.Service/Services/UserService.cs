using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.ViewModels.User;
using Victory.Service.Helpers.ImageHelper;

namespace Victory.Service.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IImageHelper _imageHelper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IImageHelper imageHelper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _imageHelper = imageHelper;
        }

        public async Task<List<UserListViewModel>> GetUserListAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var userModels = _mapper.Map<List<UserListViewModel>>(users);

            foreach (var item in userModels)
            {
                var user = await _userManager.FindByIdAsync(item.Id.ToString());

                var role = string.Join("", await _userManager.GetRolesAsync(user));

                item.Role = role;

            }

            return userModels;

        }

        public async Task<List<AppRole>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return roles;

        }

        public async Task<IdentityResult> AddAsync(AddUserViewModel viewModel)
        {
            var user = _mapper.Map<AppUser>(viewModel);

            var result = await _userManager.CreateAsync(user, string.IsNullOrEmpty(viewModel.Password) ? "" : viewModel.Password);

            if (result.Succeeded)
            {
                var role = await _roleManager.FindByIdAsync(viewModel.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, role.ToString());
                return result;
            }

            return result;
        }

        public async Task<UpdateUserViewModel> GetUserByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var userModel = _mapper.Map<UpdateUserViewModel>(user);

            return userModel;
        }

        public async Task<AppUser> GetAppUserByIdAsync(Guid Id)
        {
            return await _userManager.FindByIdAsync(Id.ToString());
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await _userManager.GetRolesAsync(user));
        }

        public async Task<IdentityResult> UpdateAsync(UpdateUserViewModel viewModel)
        {
            var user = await GetAppUserByIdAsync(viewModel.Id);


            if (viewModel.Photo!=null)
            {
                if (viewModel.PictureUrl != "default_user.jpg" )
                {
                    _imageHelper.Delete(viewModel.PictureUrl);
                }
 
                user.PictureUrl = await _imageHelper.ImageUpload(viewModel.UserName, viewModel.Photo, viewModel.ImageType); 
            }

            var userRole = await GetUserRoleAsync(user);



            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await _roleManager.FindByIdAsync(viewModel.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;

        }

        public async Task<AppRole> GetUserRoleIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var role = await GetUserRoleAsync(user);

            var appRole = await _roleManager.FindByNameAsync(role);

            return appRole;
        }

        public async Task<(IdentityResult identityResult, string? userName)> DeleteAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return (result, user.UserName);
            }
            else
                return (result, null);


        }

        public async Task<UserProfileViewModel> ProfileAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);

            var viewModel = _mapper.Map<UserProfileViewModel>(user);

            return viewModel;

        }


    }
}
