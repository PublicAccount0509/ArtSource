using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Common
{
    public enum OrderStatus
    {
        生成中,
        待处理,
        已接受,
        已发货,
        完成,

        已拒绝,
        已退款,

        已关闭,
    }
}
