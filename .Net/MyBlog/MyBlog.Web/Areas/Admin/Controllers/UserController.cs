using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Users;
using MyBlog.Service.Extensions;
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

        public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toastNotification, IValidator<AppUser> validator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _toastNotification = toastNotification;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var map = _mapper.Map<List<UserViewModel>>(users);

            foreach (var item in map)
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());

                var role = string.Join("", await _userManager.GetRolesAsync(findUser));

                item.Role = role;
            }

            return View(map);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(new UserAddViewModel { Roles = roles });
        }

        [HttpPost]

        public async Task<IActionResult> Add(UserAddViewModel userAdd)
        {
            var map = _mapper.Map<AppUser>(userAdd);
            var validation = await _validator.ValidateAsync(map);
            var roles = await _roleManager.Roles.ToListAsync();

            if (ModelState.IsValid)
            {
                map.UserName = userAdd.Email;
                var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAdd.Password) ? "" : userAdd.Password);

                if (result.Succeeded)
                {
                    var findRole = await _roleManager.FindByIdAsync(userAdd.RoleId.ToString());
                    await _userManager.AddToRoleAsync(map, findRole.ToString());

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
            var user = await _userManager.FindByIdAsync(id.ToString());

            var roles = await _roleManager.Roles.ToListAsync();

            var map = _mapper.Map<UserUpdateViewModel>(user);
            map.Roles = roles;

            return View(map);
        }

        [HttpPost]

        public async Task<IActionResult> Update(UserUpdateViewModel userUpdate)
        {
            var user = await _userManager.FindByIdAsync(userUpdate.Id.ToString());

            if (user != null)
            {
                var userRole = string.Join("", await _userManager.GetRolesAsync(user));
                var roles = await _roleManager.Roles.ToListAsync();

                if (ModelState.IsValid)
                {
                   var map = _mapper.Map(userUpdate, user);
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdate.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();

                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            await _userManager.RemoveFromRoleAsync(user, userRole);
                            var findRole = await _roleManager.FindByIdAsync(userUpdate.RoleId.ToString());
                            await _userManager.AddToRoleAsync(user, findRole.Name);

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
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage(Message.User.Delete(user.Email), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
            }

            return NotFound();
        }

    }
}
