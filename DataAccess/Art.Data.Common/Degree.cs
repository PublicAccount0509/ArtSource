using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.Data.Common
{
    public enum Degree
    {
        [DisplayText("大专")]
        大专,

        [DisplayText("本科")]
        本科,

        [DisplayText("研究生")]
        研究生,

        [DisplayText("博士")]
        博士,

        [DisplayText("海归")]
        海归
    }
}
