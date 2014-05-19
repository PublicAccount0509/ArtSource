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
        [KeepMinHeightSizeTransformer(290, 240)]
        Size_W290_MinH240,

        [FixedSizeTransformer(ConfigSettings.MINWIDTH_UPLOADEDARTWORKIMAGE, ConfigSettings.MINHEIGHT_UPLOADEDARTWORKIMAGE)]
        Size_BigImage,

        [FixedSizeTransformer(128, 100)]
        Size_W128_H100,

        [FixedSizeTransformer(180, 140)]
        Size_W180_H140
    }




}
