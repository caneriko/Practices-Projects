using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PizzaIdentityMvcApp.Core.Entities;
using PizzaIdentityMvcApp.Repository;
using System.Reflection;

namespace PizzaIdentityMvcApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                            .AddNToastNotifyToastr(new NToastNotify.ToastrOptions()
                            {
                                PositionClass = ToastPositions.TopFullWidth,
                                TimeOut = 3000
                            });

            builder.Services.AddDbContext<PizzaAppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"), x =>
                {
                    x.MigrationsAssembly(Assembly.GetAssembly(typeof(PizzaAppDbContext)).GetName().Name);
                });
            });

            builder.Services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;

                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireDigit= true;
                opt.Password.RequiredLength = 6;


                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.AllowedForNewUsers = true;

            })
                            .AddRoleManager<RoleManager<AppRole>>()
                                .AddEntityFrameworkStores<PizzaAppDbContext>()
                                  .AddDefaultTokenProviders();


            builder.Services.ConfigureApplicationCookie(opt =>
            {
                var cookie = new CookieBuilder();
                cookie.Name = "PizzaIdentity";

                opt.LoginPath = new PathString("/home/Login");
                opt.LogoutPath = new PathString("/member/Logout");
                opt.AccessDeniedPath = new PathString("/home/accessdenied");

                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(50);

            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseNToastNotify();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}