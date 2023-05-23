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
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<AppUser> _validator;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IImageHelper _imageHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toastNotification, IValidator<AppUser> validator, SignInManager<AppUser> signInManager, IImageHelper imageHelper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _toastNotification = toastNotification;
            _validator = validator;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
            _unitOfWork = unitOfWork;
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
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var getImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == user.Id, x=>x.Image);

            var map = _mapper.Map<UserProfileViewModel>(user);
            map.Image.FileName = getImage.Image.FileName;
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileViewModel userProfile)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var isVerified = await _userManager.CheckPasswordAsync(user, userProfile.CurrentPassword);

                if (isVerified && userProfile.NewPassword != null && userProfile.Photo!=null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, userProfile.CurrentPassword, userProfile.NewPassword);

                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userProfile.NewPassword, true, false);

                        user.FirstName = userProfile.FirstName;
                        user.LastName = userProfile.LastName;
                        user.PhoneNumber = userProfile.PhoneNumber;

                        var imageUpload = await _imageHelper.Upload($"{userProfile.FirstName} {userProfile.LastName}" , userProfile.Photo, ImageType.User);

                        Image image = new(imageUpload.FullName,  userProfile.Photo.ContentType, user.Email);

                        await _unitOfWork.GetRepository<Image>().AddAsync(image);

                        user.ImageId = image.Id;
                        await _userManager.UpdateAsync(user);
                        await _unitOfWork.SaveAsync();

                        _toastNotification.AddSuccessToastMessage("Şifreniz ve bilgileriniz başarıyla değiştirilmiştir");
                        return View();

                    }
                    else
                    {
                        result.AddToIdentityModelState(ModelState);
                        return View();
                    }

                }
                else if (isVerified && userProfile.Photo != null)
                {
                    await _userManager.UpdateSecurityStampAsync(user);

                    user.FirstName = userProfile.FirstName;
                    user.LastName = userProfile.LastName;
                    user.PhoneNumber = userProfile.PhoneNumber;

                    var imageUpload = await _imageHelper.Upload($"{userProfile.FirstName} {userProfile.LastName}", userProfile.Photo, ImageType.User);

                    Image image = new(imageUpload.FullName, userProfile.Photo.ContentType, user.Email);

                    await _unitOfWork.GetRepository<Image>().AddAsync(image);

                    user.ImageId = image.Id;
                    await _userManager.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();

                    _toastNotification.AddSuccessToastMessage("Bilgileriniz başarıyla değiştirilmiştir");
                    return View(userProfile);
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("Bilgileriniz güncellenirken bir hata oluştu");
                    return View(userProfile);
                }
            } 


            return View();
        }
    }
}
