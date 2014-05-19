using Art.Common;
using Art.Data.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.BussinessLogic
{
    public class ImageInfo
    {
        public string ImagePath { get; set; }
        public int ImageTypeId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class ImageInfosTranslator
    {
        public static readonly ImageInfosTranslator Instance = new ImageInfosTranslator();

        public IList<ArtworkImage> TranslateToArtworkImage(IList<ImageInfo> images)
        {
            var to = images.Select(i => new ArtworkImage
            {
                ImagePath = i.ImagePath,
                ImageType = (ArtworkImageResizeType)i.ImageTypeId,
                Height = i.Height,
                Width = i.Width
            }).ToList();
            return to;
        }

        public IList<ArtistImage> TranslateToArtistImage(IList<ImageInfo> images)
        {
            var to = images.Select(i => new ArtistImage
            {
                ImagePath = i.ImagePath,
                ImageType = (ArtistImageType)i.ImageTypeId,
                Height = i.Height,
                Width = i.Width
            }).ToList();
            return to;
        }
    }

    public class BussinessLogicHelper
    {
        public static List<ImageInfo> GenerateImages<TImageTypeEnum>(string imageFullFileName) where TImageTypeEnum : struct
        {
            var images = new List<ImageInfo>();

            var enumType = typeof(TImageTypeEnum);
            var items = Enum.GetValues(enumType);
            foreach (var item in items)
            {
                var mi = enumType.GetMember(item.ToString()).First();
                var attributes = mi.GetCustomAttributes(false);

                var attribute = attributes.FirstOrDefault(i => typeof(IImageFileTransformer).IsAssignableFrom(i.GetType()));
                if (attribute != null)
                {
                    var transformer = attribute as IImageFileTransformer;
                    var destFullFileName = string.Format("{0}\\{1}_{2}{3}", Path.GetDirectoryName(imageFullFileName), Path.GetFileNameWithoutExtension(imageFullFileName), item.ToString(), Path.GetExtension(imageFullFileName));
                    var size = transformer.Transform(imageFullFileName, destFullFileName);
                    images.Add(new ImageInfo
                    {
                        ImagePath = Path.GetFileName(destFullFileName),
                        ImageTypeId = (int)item,
                        Width = size.Width,
                        Height = size.Height
                    });
                }
            }
            return images;
        }
    }
}
