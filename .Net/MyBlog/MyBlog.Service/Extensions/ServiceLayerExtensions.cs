using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Data.Context;
using MyBlog.Data.Repositories.Abstarctions;
using MyBlog.Data.Repositories.Concretes;
using MyBlog.Data.UnitOfWorks;
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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
