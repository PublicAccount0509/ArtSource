using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Art.Data.Domain.Access;
using Art.BussinessLogic;
using System;
using System.Web;

namespace Art.Website
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>), new HttpContextLifetimeManager(typeof(IRepository<>)));
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));
            container.RegisterType<IDbContext, ArtDbContext>(new HttpContextLifetimeManager(typeof(IDbContext)));

            container.RegisterType<IAdminUserBussinessLogic, AdminUserBussinessLogic>(new HttpContextLifetimeManager(typeof(IAdminUserBussinessLogic)));
            container.RegisterType<IArtistBussinessLogic, ArtistBussinessLogic>(new HttpContextLifetimeManager(typeof(IArtistBussinessLogic)));
            container.RegisterType<IArtworkBussinessLogic, ArtworkBussinessLogic>(new HttpContextLifetimeManager(typeof(IArtworkBussinessLogic)));
            container.RegisterType<IOrderBussinessLogic, OrderBussinessLogic>(new HttpContextLifetimeManager(typeof(IOrderBussinessLogic)));
            container.RegisterType<ICustomerBussinessLogic, CustomerBussinessLogic>(new HttpContextLifetimeManager(typeof(ICustomerBussinessLogic)));
            container.RegisterType<IMessageBussinessLogic, MessageBussinessLogic>(new HttpContextLifetimeManager(typeof(IMessageBussinessLogic)));
        }
    }

    public class HttpContextLifetimeManager : LifetimeManager, IDisposable
    {
        private Type _type;
        public HttpContextLifetimeManager(Type type)
        {
            _type = type;
        }
        public override object GetValue()
        {
            return HttpContext.Current.Items[_type.AssemblyQualifiedName];
        }
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(_type.AssemblyQualifiedName);
        }
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[_type.AssemblyQualifiedName] = newValue;
        }
        public void Dispose()
        {
            RemoveValue();
        }
    }
}