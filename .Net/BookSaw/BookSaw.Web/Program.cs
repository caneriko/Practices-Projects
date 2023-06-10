using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookSaw.Core.Entities;
using BookSaw.Core.Repositories;
using BookSaw.Core.Services;
using BookSaw.Core.UnitOfWorks;
using BookSaw.Repository;
using BookSaw.Repository.Repositories;
using BookSaw.Repository.UnitOfWorks;
using BookSaw.Service.AutoMappings;
using BookSaw.Service.Extensions;
using BookSaw.Service.FluentValidations;
using BookSaw.Service.IdentityHelpers;
using BookSaw.Service.Modules;
using BookSaw.Service.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Reflection;

namespace BookSaw.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();

            builder.Services.AddIdentityWithExt();

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<AppUserValidator>();
            }).AddNToastNotifyToastr(new ToastrOptions()
            {
                TimeOut = 3000,
                PositionClass = ToastPositions.TopRight
            });

              

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(container => container.RegisterModule(new RepoServiceModule()));

            builder.Services.AddDbContext<BookSawDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(BookSawDbContext)).GetName().Name);
                });


            });


            builder.Services.AddAutoMapper(typeof(UserProfile));


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
            app.UseSession();

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