using Autofac;
using System.Reflection;
using Victory.Core.UnitOfWork;
using Victory.Repository.UnitOfWork;
using Victory.Service.Helpers.ImageHelper;
using Victory.Service.Services;

namespace Victory.Web.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ImageHelper>().As<IImageHelper>();

            var webAssembly = Assembly.GetExecutingAssembly();
            var serviceAssembly = Assembly.GetAssembly(typeof(CategoryService));

            builder.RegisterAssemblyTypes(serviceAssembly, webAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope(); 


        }
    }
}
