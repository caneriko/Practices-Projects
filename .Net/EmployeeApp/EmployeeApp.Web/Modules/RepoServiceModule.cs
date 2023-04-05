using Autofac;
using EmployeeApp.Core.Repositories;
using EmployeeApp.Core.Services;
using EmployeeApp.Core.UnitOfWorks;
using EmployeeApp.Repository;
using EmployeeApp.Repository.Repositories;
using EmployeeApp.Repository.UnitOfWorks;
using EmployeeApp.Service.Mapping;
using EmployeeApp.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace EmployeeApp.Web.Modules
{
    public class RepoServiceModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            var webAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(EmpAppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(webAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(webAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

        }


    }
}
