using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public class FixedSizeTransformerAttribute : Attribute, IImageFileTransformer
    {
        private int _width;
        private int _height;

        public FixedSizeTransformerAttribute(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public Size Transform(string srcPath, string destPath)
        {
            var size = ImageSizeTransformManager.Instance.ResizeImageToSize(srcPath, destPath, _width, _height);
            return size;
        }
    }
}
