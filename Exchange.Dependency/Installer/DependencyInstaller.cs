using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Exchange.Core.Services.Implementation;
using Exchange.Dependency.UnitOfWork;
using Exchange.NHibernateBase.Mapping;
using Exchange.NHibernateBase.Repositories;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;
using System.Reflection;

namespace Exchange.Dependency.Installer
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.ComponentRegistered += Kernel_ComponentRegistered;

            //Register all components

            container.Register(
                //Nhibernate session factory
                Component.For<ISessionFactory>().UsingFactoryMethod(CreateNhSessionFactory).LifeStyle.Singleton,

                //Unitofwork interceptor
                Component.For<NHUnitOfWorkInterceptor>().LifeStyle.Transient,

                //All repositories
                Classes.FromAssembly(Assembly.GetAssembly(typeof(NHCustomerRepository)))
                    .InSameNamespaceAs<NHCustomerRepository>()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient(),
                Classes.FromAssembly(Assembly.GetAssembly(typeof(CustomerService)))
                    .InSameNamespaceAs<CustomerService>()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient(),
                Classes.FromAssembly(Assembly.GetAssembly(typeof(UserService)))
                    .InSameNamespaceAs<UserService>()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                // Classes.FromAssembly(Assembly.GetAssembly(typeof(NHMembershipProvider))).InSameNamespaceAs<NHMembershipProvider>().WithService.DefaultInterfaces().LifestyleTransient()
                );

            //logger
            // container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
        }

        /// <summary>
        ///     Creates NHibernate Session Factory.
        /// </summary>
        /// <returns>NHibernate Session Factory</returns>
        /// register both custom membership mapping and default nhibernatebase mapping
        private static ISessionFactory CreateNhSessionFactory()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ShoppeConn"].ConnectionString;
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connStr))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(CustomerMap))))
                .BuildSessionFactory();
        }

        private void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            //Intercept all methods of all repositories.
            if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Implementation) ||
                UnitOfWorkHelper.IsProviderClass(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NHUnitOfWorkInterceptor)));
            }

            //Intercept all methods of classes those have at least one method that has UnitOfWork attribute.
            foreach (MethodInfo method in handler.ComponentModel.Implementation.GetMethods())
            {
                if (UnitOfWorkHelper.HasUnitOfWorkAttribute(method))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NHUnitOfWorkInterceptor)));
                    return;
                }
            }
        }
    }
}