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
            container.RegisterType(typeof(IRepository<>),typeof(EfRepository<>));
            container.RegisterType<IDbContext, ArtDbContext>(new HttpContextLifetimeManager<IDbContext>());


            container.RegisterType<IAdminUserBussinessLogic, AdminUserBussinessLogic>();
            container.RegisterType<IArtistBussinessLogic, ArtistBussinessLogic>();
            container.RegisterType<IArtworkBussinessLogic, ArtworkBussinessLogic>();
            container.RegisterType<IOrderBussinessLogic, OrderBussinessLogic>();
            container.RegisterType<ICustomerBussinessLogic, CustomerBussinessLogic>();
            container.RegisterType<IMessageBussinessLogic, MessageBussinessLogic>();
        }
    }

    public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
    {
        public override object GetValue()
        {
            return HttpContext.Current.Items[typeof(T).AssemblyQualifiedName];
        }
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(typeof(T).AssemblyQualifiedName);
        }
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[typeof(T).AssemblyQualifiedName] = newValue;
        }
        public void Dispose()
        {
            RemoveValue();
        }
    }
}