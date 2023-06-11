using BookSaw.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.TagHelpers
{
    public class UserRoleNamesTagHelper : TagHelper
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRoleNamesTagHelper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public int Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());

            var userRoles = await _userManager.GetRolesAsync(user);

            userRoles = userRoles.ToList();

            var stringBuilder = new StringBuilder();


            foreach (var role in userRoles)
            {
                stringBuilder.Append(@$" <span class='badge badge-warning m-2  '>{role.ToLower()}</span> ");
            }

            output.Content .SetHtmlContent(stringBuilder.ToString());


         }
    }
}
