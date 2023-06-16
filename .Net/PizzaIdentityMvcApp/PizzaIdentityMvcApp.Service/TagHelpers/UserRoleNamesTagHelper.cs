using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PizzaIdentityMvcApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIdentityMvcApp.Service.TagHelpers
{
    public class UserRoleNamesTagHelper : TagHelper
    {
        public string UserId { get; set; } = null!;

        private readonly UserManager<AppUser> _userManager;

        public UserRoleNamesTagHelper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            var userRoles = await _userManager.GetRolesAsync(user);


            var stringBuilder = new StringBuilder();

            foreach ( var role in userRoles) 
            {
                stringBuilder.Append(@$"<span class='m-2'>{role.ToLower()}</span>");

            }


            output.Content.SetHtmlContent(stringBuilder.ToString());
        }

    }
}
