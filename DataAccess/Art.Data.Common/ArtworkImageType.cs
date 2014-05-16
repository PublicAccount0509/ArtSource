using Art.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.Data.Common
{
    public enum ArtworkImageResizeType
    {
        [KeepMinHeightSizeTransformer(290, 240)]
        Size_W290_MinH240,  //瀑布流图片宽度：290px  ，最小高度为240px

        [FixedSizeTransformer(ConfigSettings.MINWIDTH_UPLOADEDARTWORKIMAGE, ConfigSettings.MINHEIGHT_UPLOADEDARTWORKIMAGE)]
        Size_BigImage,  //作品详情图片展示：600x420px

        [FixedSizeTransformer(128, 100)]
        Size_W128_H100,  //我的评价 图片展示：128x100px

        [FixedSizeTransformer(180, 140)]
        Size_W180_H140   //购物盒图片&订单详情：180x140px
    }




}
