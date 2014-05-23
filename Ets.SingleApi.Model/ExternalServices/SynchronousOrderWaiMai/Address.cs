using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ets.SingleApi.Model.ExternalServices
{
    public class address
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tel { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string addrbuilding { get; set; }
        public string addrdetail { get; set; }
        public string regioncode { get; set; }
        public int? sex { get; set; }
    }
}
