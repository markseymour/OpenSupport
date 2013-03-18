using System;
using System.Linq;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NHibernate;
using OpenSupport.Core.Models;
using OpenSupport.DataAccess;

namespace OpenSupport.Setup
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            var appAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterControllers(appAssemblies);
            
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(x => x.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IDependency))))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.Register(x => OpenSupportSessionFactory.CreateSessionFactory()).SingleInstance();
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).InstancePerHttpRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}