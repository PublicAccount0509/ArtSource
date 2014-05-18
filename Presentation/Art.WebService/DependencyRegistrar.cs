using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac.Integration.WebApi;
using Art.Data.Domain.Access;
using Art.BussinessLogic;

namespace Art.WebService
{
    public class DependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ArtDbContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterType<AdminUserBussinessLogic>().As<IAdminUserBussinessLogic>().InstancePerRequest();
            builder.RegisterType<ArtistBussinessLogic>().As<IArtistBussinessLogic>().InstancePerRequest();
            builder.RegisterType<ArtworkBussinessLogic>().As<IArtworkBussinessLogic>().InstancePerRequest();
            builder.RegisterType<OrderBussinessLogic>().As<IOrderBussinessLogic>().InstancePerRequest();
            builder.RegisterType<CustomerBussinessLogic>().As<ICustomerBussinessLogic>().InstancePerRequest();
            builder.RegisterType<MessageBussinessLogic>().As<IMessageBussinessLogic>().InstancePerRequest();
        }
    }
}