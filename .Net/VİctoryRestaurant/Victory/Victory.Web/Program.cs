using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NToastNotify;
using System.Reflection;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.UnitOfWork;
using Victory.Repository;
using Victory.Repository.UnitOfWork;
using Victory.Service.Describers;
using Victory.Service.FluentValidations;
using Victory.Service.Mapping;
using Victory.Service.Services;
using Victory.Web.Modules;

namespace Victory.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();


            // Add services to the container.
            builder.Services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<SignUpValidator>();
            })
                .AddNToastNotifyToastr(new ToastrOptions()
                {
                    TimeOut = 3000,
                    PositionClass = ToastPositions.TopRight
                });

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new ServiceModule()));


            builder.Services.AddAutoMapper(typeof(SignUpProfile));
 
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            builder.Services.AddDbContext<VictoryDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"), opt =>
                {
                    opt.MigrationsAssembly(Assembly.GetAssembly(typeof(VictoryDbContext)).GetName().Name);
                });
            });



            builder.Services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            }).AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<VictoryDbContext>()
                    .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = new PathString("/Admin/Auth/Login");
                config.LoginPath = new PathString("/Admin/Auth/Logout");
                config.Cookie = new CookieBuilder
                {
                    Name = "Victory",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };

                config.SlidingExpiration = true;
                config.ExpireTimeSpan = TimeSpan.FromDays(30);
                config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
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
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(

                name: "area",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"


                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}