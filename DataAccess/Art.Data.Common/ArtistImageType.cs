using Art.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.Data.Common
{
    public enum ArtistImageType
    {
        [FixedSizeTransformer(88, 88)]
        Size_W88_H88,//个人中心

        [FixedSizeTransformer(68, 68)]
        Size_W68_H68,//作品详情

        [FixedSizeTransformer(44, 44)]
        Size_W44_H44 //瀑布流头像
    }
}
