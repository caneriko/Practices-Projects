using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Data.Context;
using MyBlog.Data.Repositories.Abstarctions;
using MyBlog.Data.Repositories.Concretes;
using MyBlog.Data.UnitOfWorks;
using MyBlog.Service.FluentValidations;
using MyBlog.Service.Helpers.Images;
using MyBlog.Service.Services.Abstractions;
using MyBlog.Service.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services )
        {
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IImageHelper,ImageHelper>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true;

                opt.ValidatorOptions.LanguageManager.Culture=new System.Globalization.CultureInfo("tr");
            });

            return services;
        }
    }
}
