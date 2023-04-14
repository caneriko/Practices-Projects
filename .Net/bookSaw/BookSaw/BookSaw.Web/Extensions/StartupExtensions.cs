using BookSaw.Core.Models;
using BookSaw.Repository;
using BookSaw.Service.CustomValidator;
using BookSaw.Service.Localization;

namespace BookSaw.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExtension(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "1234567890._*qwertyuopasdfghjklizxcvbnm";


                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;

                options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;



            }).AddPasswordValidator<PasswordValidator>()
            .AddUserValidator<UserValidator>()
            .AddErrorDescriber<LocalizationIdentityErrorDescriber>()
                .AddEntityFrameworkStores<BookSawDbContext>();
        }
    }
}
