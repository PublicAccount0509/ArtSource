using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class Address : BaseEntity
    {
        public virtual Customer Customer { get; set; }

        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Detail{ get; set; }
    }
}
