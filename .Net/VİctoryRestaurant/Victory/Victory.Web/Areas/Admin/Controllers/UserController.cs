using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.ViewModels.User;
using Victory.Service.Services;
using Victory.Service.ToastrMessages;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IToastNotification _toast;
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        

        public UserController(IUserService userService, IToastNotification toast, UserManager<AppUser> userManager, IMapper mapper)
        {
            _userService = userService;
            _toast = toast;
            _userManager = userManager;
            _mapper = mapper;
        }

        public  async Task<IActionResult> Index()
        {
            var viewModel = await _userService.GetUserListAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Roles = await _userService.GetRolesAsync();


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel viewModel)
        {
            ViewBag.Roles = await _userService.GetRolesAsync();

            if (ModelState.IsValid)
            {
                var result = await _userService.AddAsync(viewModel);

                if (result.Succeeded)
                {
                    _toast.AddSuccessToastMessage(ResultMessage.User.Add(viewModel.UserName), new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View();
                    }
                }

            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var viewModel = await _userService.GetUserByIdAsync(id);

            ViewBag.Roles = await _userService.GetRolesAsync();

            ViewBag.Role = await _userService.GetUserRoleIdAsync(id);


            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel viewModel)
        {

            ViewBag.Roles = await _userService.GetRolesAsync();

            var user = await _userService.GetAppUserByIdAsync(viewModel.Id);

            if (user!=null)
            {

                if (ModelState.IsValid)
                {

                    var map = _mapper.Map(viewModel, user);

                    user.SecurityStamp = Guid.NewGuid().ToString();

                    var result = await _userService.UpdateAsync(viewModel);

                    if (result.Succeeded)
                    {
                        _toast.AddSuccessToastMessage(ResultMessage.User.Update(viewModel.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        return View(viewModel);
                    }

                }
                else
                {
                    return View(viewModel);
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _userService.DeleteAsync(id);

            if (result.identityResult.Succeeded)
            {
                _toast.AddSuccessToastMessage(ResultMessage.User.Delete(result.userName), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                foreach (var error in result.identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return NotFound();
        }


        public async Task<IActionResult> Profile(string name)
        {

            var viewModel = await _userService.ProfileAsync(name);

 
            return View(viewModel);
        }

    }
}
