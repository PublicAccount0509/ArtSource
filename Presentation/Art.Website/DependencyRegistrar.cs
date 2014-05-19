using Art.Data.Domain.Access;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using System.Reflection;
using Art.BussinessLogic;

namespace Art.Website
{
    public class DependencyRegistrar// : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ArtDbContext>().As<IDbContext>().InstancePerHttpRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();

            builder.RegisterType<AdminUserBussinessLogic>().As<IAdminUserBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<ArtistBussinessLogic>().As<IArtistBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<ArtworkBussinessLogic>().As<IArtworkBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<OrderBussinessLogic>().As<IOrderBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<CustomerBussinessLogic>().As<ICustomerBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<MessageBussinessLogic>().As<IMessageBussinessLogic>().InstancePerHttpRequest();
        }
    }
}