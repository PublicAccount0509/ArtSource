using Art.Data.Domain.Access;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //builder.Register<IDbContext>(c => new NopObjectContext(dataProviderSettings.DataConnectionString)).InstancePerHttpRequest();
        }
    }
}