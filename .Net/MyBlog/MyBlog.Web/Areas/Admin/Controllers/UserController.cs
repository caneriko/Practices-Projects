using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Users;
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

        public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toastNotification)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _toastNotification = toastNotification;
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
            var roles = await _roleManager.Roles.ToListAsync();


            if (ModelState.IsValid)
            {
                map.UserName = userAdd.Email;
                var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAdd.Password) ? "" : userAdd.Password );

                if (result.Succeeded)
                {
                    var findRole = await _roleManager.FindByIdAsync(userAdd.RoleId.ToString());
                    await _userManager.AddToRoleAsync(map, findRole.ToString());

                    _toastNotification.AddSuccessToastMessage(Message.User.Add(userAdd.Email), new ToastrOptions { Title = "Başarılı!" });


                    return RedirectToAction("Index", "User", new { Area = "Admin" });

                }
                else {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View(new UserAddViewModel { Roles = roles });
                    }
                }
            }

            return View(new UserAddViewModel { Roles = roles });

        }

    }
}
