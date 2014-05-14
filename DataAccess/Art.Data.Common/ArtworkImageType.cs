using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Common
{
    public enum ArtworkImageResizeType
    {
        Type1,  //瀑布流图片宽度：290px  ，最小高度为240px
        Type2,  //作品详情图片展示：600x420px
        Type3,  //我的评价 图片展示：128x100px
        Type4   //购物盒图片&订单详情：180x140px
    }
}
