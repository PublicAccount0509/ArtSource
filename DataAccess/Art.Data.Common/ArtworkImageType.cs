using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Common
{
    public enum ArtworkImageResizeType
    {
        Size_W290_MinH240,  //瀑布流图片宽度：290px  ，最小高度为240px
        Size_W600_H420,  //作品详情图片展示：600x420px
        Size_W128_H100,  //我的评价 图片展示：128x100px
        Size_W180_H140   //购物盒图片&订单详情：180x140px
    }
}
