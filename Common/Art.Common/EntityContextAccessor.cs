using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Art.Common
{
    public class EntityContextAccessor
    {
        public static DbContext CurrentDbContext
        {
            get
            {
                var entityContext = HttpContext.Current.Items["_EntityContext"] as DbContext;
                return entityContext;
            } 
        }
    }
}
