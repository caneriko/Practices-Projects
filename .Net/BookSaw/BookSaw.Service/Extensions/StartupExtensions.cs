using BookSaw.Core.Entities;
using BookSaw.Repository;
using BookSaw.Service.IdentityHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.Extensions
{
    public static class StartupExtensions
    {

        public static IServiceCollection AddIdentityWithExt(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;

                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = false;

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                opt.Lockout.MaxFailedAccessAttempts = 3;

            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddPasswordValidator<PasswordValidator>()
                .AddUserValidator<UserValidator>()
                 .AddEntityFrameworkStores<BookSawDbContext>()
                     .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie = new CookieBuilder
                {
                    Name = "BookSaw",
                    HttpOnly = true,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest,
                    SameSite = SameSiteMode.Strict
                };

                opt.LoginPath = new PathString("/Admin/Auth/Login");
                opt.LogoutPath = new PathString("/Admin/Auth/Logout");
                opt.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(60);


            });

            return services;
        }
    }
}
