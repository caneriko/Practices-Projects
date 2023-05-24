using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data.UnitOfWorks;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Enums;
using MyBlog.Entity.ViewModels.Articles;
using MyBlog.Entity.ViewModels.Users;
using MyBlog.Service.Extensions;
using MyBlog.Service.Helpers.Images;
using MyBlog.Service.Services.Abstractions;
using MyBlog.Web.ResultMessages;
using NToastNotify;
using System.Data;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<AppUser> _validator;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IToastNotification toastNotification, IValidator<AppUser> validator, IUserService userService)
        {
            _mapper = mapper;
            _toastNotification = toastNotification;
            _validator = validator;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _userService.GetAllUsersWithRoleAsync();

            return View(result);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _userService.GetAllRolesAsync();

            return View(new UserAddViewModel { Roles = roles });
        }

        [HttpPost]

        public async Task<IActionResult> Add(UserAddViewModel userAdd)
        {
            var map = _mapper.Map<AppUser>(userAdd);
            var validation = await _validator.ValidateAsync(map);
            var roles = await _userService.GetAllRolesAsync();


            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(userAdd);

                if (result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage(Message.User.Add(userAdd.Email), new ToastrOptions { Title = "Başarılı!" });

                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddViewModel { Roles = roles });
                }
            }

            return View(new UserAddViewModel { Roles = roles });

        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid id)
        {
            var user = await _userService.GetAppUserByIdAsync(id);

            var roles = await _userService.GetAllRolesAsync();

            var map = _mapper.Map<UserUpdateViewModel>(user);
            map.Roles = roles;

            return View(map);
        }

        [HttpPost]

        public async Task<IActionResult> Update(UserUpdateViewModel userUpdate)
        {
            var user = await _userService.GetAppUserByIdAsync(userUpdate.Id);

            if (user != null)
            {
                var roles = await _userService.GetAllRolesAsync();

                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdate, user);
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdate.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await _userService.UpdateUserAsync(userUpdate);

                        if (result.Succeeded)
                        {
                            _toastNotification.AddSuccessToastMessage(Message.User.Update(userUpdate.Email), new ToastrOptions { Title = "Başarılı!" });

                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateViewModel { Roles = roles });

                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateViewModel { Roles = roles });
                    }
                }
            }

            return NotFound();
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteUserAsync(id);

            if (result.identityResult.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage(Message.User.Delete(result.email), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await _userService.GetUserProfileAsync();

            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileViewModel userProfile)
        {

            if (ModelState.IsValid)
            {
                var result = await _userService.UserProfileUpdateAsync(userProfile);

                if (result)
                {
                    _toastNotification.AddSuccessToastMessage("Profil güncelleme tamamlandı", new ToastrOptions { Title = "Başarılı!" });

                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await _userService.GetUserProfileAsync();

                    _toastNotification.AddErrorToastMessage("Profil güncelleme tamamlanamadı", new ToastrOptions { Title = "Başarısız!" });
                    return View(profile);
                }
            }

            else
                return NotFound();
        }



    }

}





