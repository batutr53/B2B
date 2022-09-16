using Module = Autofac.Module;
using System.Reflection;
using Autofac;
using B2B.DataAccess.Repositories.Concrete;
using B2B.DataAccess.Repositories.Abstract;
using B2B.Business.Services.Concrete;
using B2B.Business.Services.Abstract;
using B2B.DataAccess;
using B2B.Business.Mapping;
using Castle.DynamicProxy;
using Autofac.Extras.DynamicProxy;
using B2B.Core.Utilities.Interceptors;

namespace B2B.Business.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Services<>)).As(typeof(IServices<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(B2BDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().
                InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().
                InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
              
        }
    }
}
