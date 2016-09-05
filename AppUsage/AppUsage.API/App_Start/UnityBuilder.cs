using AppUsage.Application.Contract.Contracts;
using AppUsage.Application.Service;
using AppUsage.Business.Contract;
using AppUsage.Business.Service;
using AppUsage.Infrastructure.Data;
using AppUsage.Infrastructure.Data.Contexts;
using AppUsage.Infrastructure.Data.Repositories;
using AppUsage.Infrastructure.DependencyInjection;
using AppUsage.Model.Contexts;
using Microsoft.Practices.Unity;

namespace AppUsage.API.App_Start
{
    public static class UnityBuilder
    {
        public static void Build(IUnityContainer container)
        {
            InjectFactory.SetContainer(container);

            //Assembly[] assemblies = BuildManager.GetReferencedAssemblies().OfType<Assembly>().ToArray();

            //container.RegisterTypes(
            //    AllClasses.FromLoadedAssemblies()
            //        .Where(
            //            a =>
            //                a.FullName.StartsWith("AppUsage")
            //        //a.FullName.StartsWith("AppUsage") &&
            //        //(a.FullName.EndsWith("Business") || a.FullName.EndsWith("Application"))
            //        ),
            //        WithMappings.FromMatchingInterface,
            //        WithName.Default,
            //        WithLifetime.Hierarchical);

            buildContext(container, new HierarchicalLifetimeManager());
            buildInfrastructure(container, new HierarchicalLifetimeManager());
            buildBusinessServices(container, new HierarchicalLifetimeManager());
            buildApplicationServices(container, new HierarchicalLifetimeManager());
        }

        private static void buildApplicationServices(IUnityContainer container, LifetimeManager lifetimeManager)
        {
            container.RegisterType<IPartnerApplicationService, PartnerApplicationService>(lifetimeManager);
        }

        private static void buildBusinessServices(IUnityContainer container, LifetimeManager lifetimeManager)
        {
            container.RegisterType<IPartnerBusinessService, PartnerBusinessService>(lifetimeManager);
        }

        private static void buildInfrastructure(IUnityContainer container, LifetimeManager lifetimeManager)
        {
            container.RegisterType(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), lifetimeManager);
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), lifetimeManager);
        }

        private static void buildContext(IUnityContainer container, LifetimeManager lifetimeManager)
        {
            container.RegisterType<IDbContext, AppUsageDbContext>(lifetimeManager, new InjectionConstructor("AppUsageDbContext"));
        }
    }
}