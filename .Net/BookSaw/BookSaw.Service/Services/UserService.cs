using AutoMapper;
using BookSaw.Core.Entities;
using BookSaw.Core.Services;
using BookSaw.Core.ViewModels.User;
using BookSaw.Service.Helpers;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IValidator<AppUser> _validator;
        private readonly IImageHelper _imageHelper;


        public UserService(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager, IValidator<AppUser> validator, IImageHelper imageHelper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _validator = validator;
            _imageHelper = imageHelper;
        }


        public async Task<IdentityResult> SignUp(UserSignUpViewModel viewModel)
        {
            var user = _mapper.Map<AppUser>(viewModel);

            var result = await _userManager.CreateAsync(user, viewModel.RePassword);

            return result;

        }

        public async Task<List<UserListViewModel>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var viewModel = _mapper.Map<List<UserListViewModel>>(users);

            return viewModel;
        }

        public async Task<UserProfileViewModel> GetUserProfileAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var viewModel = _mapper.Map<UserProfileViewModel>(user);

            return viewModel;

        }

        public async Task<bool> CheckPasswordAsync(string userName, UserChangePasswordViewModel viewModel)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var passwordResult = await _userManager.CheckPasswordAsync(user, viewModel.OldPassword);

            return passwordResult;

        }

        public async Task<IdentityResult> ChangePasswordAsync(string userName, UserChangePasswordViewModel viewModel)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var passwordResult = await _userManager.ChangePasswordAsync(user, viewModel.OldPassword, viewModel.ConfirmPassword);

            if (passwordResult.Succeeded)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                return passwordResult;
            }

            return passwordResult;

        }

        public async Task<UserUpdateViewModel> GetUserUpdateModelAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var viewModel = _mapper.Map<UserUpdateViewModel>(user);

            return viewModel;
        }

        public async Task<AppUser> GetAppUserByIdAsync(int Id)
        {
            return await _userManager.FindByIdAsync(Id.ToString());
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateViewModel viewModel)
        {

            var user = await _userManager.FindByIdAsync(viewModel.Id.ToString());


            if (viewModel.Photo != null)
            {
                if (viewModel.PictureUrl != "default_user.jpg")
                {
                    _imageHelper.Delete(viewModel.PictureUrl);
                }

                user.PictureUrl = await _imageHelper.ImageUpload(viewModel.UserName, viewModel.Photo, viewModel.ImageType);
            }




            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.UpdateSecurityStampAsync(user);

            }

            return result;


        }

         

    }
}
