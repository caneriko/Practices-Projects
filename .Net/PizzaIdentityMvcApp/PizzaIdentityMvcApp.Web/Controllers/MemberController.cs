using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PizzaIdentityMvcApp.Core.Entities;
using PizzaIdentityMvcApp.Core.ViewModels.Role;
using PizzaIdentityMvcApp.Core.ViewModels.User;

namespace PizzaIdentityMvcApp.Web.Controllers
{
    //[Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IToastNotification _toast;


        public MemberController(SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IToastNotification toast, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _toast = toast;
            _userManager = userManager;
        }

        public IActionResult Deneme()
        {
            return View();
        }



        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
                
        }


        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();

            var viewModel = new List<UserListViewModel>();

            foreach (var item in users)
            {
                viewModel.Add(new() { Id = item.Id, Email = item.Email, FullName = item.FullName, UserName = item.UserName });

            }

            return View(viewModel);
        }



        public async Task<IActionResult> RoleList()
        {
            var roles = await _roleManager.Roles.Select(x => new RoleListViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
                

            return View(roles);
        }

        public IActionResult RoleAdd()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleAdd(RoleAddViewModel viewModel)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Name = viewModel.Name });

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();
                return RedirectToAction(nameof(MemberController.RoleList));
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View();
        }

        public async Task<IActionResult> RoleUpdate(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var viewModel = new RoleUpdateViewModel()
            {
                Id = role.Id,
                Name = role.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel viewModel)
        {

            var role = await _roleManager.FindByIdAsync(viewModel.Id);

            role.Name=viewModel.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();

                return RedirectToAction(nameof(MemberController.RoleList));
            }

            _toast.AddErrorToastMessage();
            return View();

        }


        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage();

            }

            _toast.AddErrorToastMessage();

            return RedirectToAction(nameof(MemberController.RoleList));


        }


    }
}
