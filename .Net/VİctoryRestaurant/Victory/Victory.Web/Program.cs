using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Victory.Core.Services;
using Victory.Core.UnitOfWork;
using Victory.Repository;
using Victory.Repository.UnitOfWork;
using Victory.Service.Mapping;
using Victory.Service.Services;

namespace Victory.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(typeof(SignUpProfile));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<ISignUpService, SignUpService>();

            builder.Services.AddDbContext<VictoryDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"), opt =>
                {
                    opt.MigrationsAssembly(Assembly.GetAssembly(typeof(VictoryDbContext)).GetName().Name);
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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