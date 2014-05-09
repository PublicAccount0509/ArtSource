using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;
namespace Art.Data.Common
{
    public enum AuctionType:int
    {
        一口价 = 1,

        [DisplayText("竞价拍--上升价格拍")]
        增价拍,

        [DisplayText("竞价拍-下降价格拍")]
        减价拍
    }
}
