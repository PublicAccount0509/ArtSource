using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    internal class ImageSizeTransformManager
    {
        public static readonly ImageSizeTransformManager Instance = new ImageSizeTransformManager();
        private ImageSizeTransformManager()
        {

        }

        public Size ResizeImageToWidth(string srcPath, string destPath, int destWidth)
        {
            var bitmap = new Bitmap(srcPath);
            var srcWidth = bitmap.Width;
            var srcHeight = bitmap.Height;

            double factor = (double)destWidth / srcWidth;
            var destHeight = (int)(srcHeight * factor);

            return ResizeImage(bitmap, destPath, destWidth, destHeight);
        }

        public Size ResizeImageToWidth(string srcPath, string destPath, int destWidth, int minHeight)
        {
            var bitmap = new Bitmap(srcPath);
            var srcWidth = bitmap.Width;
            var srcHeight = bitmap.Height;

            double factor = (double)destWidth / srcWidth;
            var destHeight = (int)(srcHeight * factor);
            if (destHeight <= minHeight)
            {
                destHeight = minHeight;
                factor = (double)destHeight / srcHeight;
            }

            var validWidth = (int)(destWidth / factor);
            var redundantWidth = srcWidth - validWidth;

            var srcRect = new Rectangle(redundantWidth / 2, 0, validWidth, srcHeight);
            return ResizeImage(bitmap, destPath, destWidth, destHeight, srcRect);
        }

        public Size ResizeImageToHeight(string srcPath, string destPath, int destHeight)
        {
            var bitmap = new Bitmap(srcPath);
            var srcWidth = bitmap.Width;
            var srcHeight = bitmap.Height;

            double factor = (double)destHeight / srcHeight;
            var destWidth = (int)(srcWidth * factor);

            return ResizeImage(bitmap, destPath, destWidth, destHeight);
        }

        public Size ResizeImageToSize(string srcPath, string destPath, int destWidth, int destHeight)
        {
            var bitmap = new Bitmap(srcPath);
            var srcWidth = bitmap.Width;
            var srcHeight = bitmap.Height;

            double factorWidth = (double)destWidth / srcWidth;
            double factorHeight = (double)destHeight / srcHeight;
            var invalidFactor = Math.Max(factorWidth, factorHeight);
            Rectangle srcRect;
            if (factorWidth > factorHeight)
            {
                var validHeight = (int)(destHeight / invalidFactor);
                var redundantHeight = srcHeight - validHeight;
                srcRect = new Rectangle(0, redundantHeight / 2, srcWidth, validHeight);
            }
            else
            {
                var validWidth = (int)(destWidth / invalidFactor);
                var redundantWidth = srcWidth - validWidth;
                srcRect = new Rectangle(redundantWidth / 2, 0, validWidth, srcHeight);
            }

            return ResizeImage(bitmap, destPath, destWidth, destHeight, srcRect);
        }

        public Size ResizeImage(string srcPath, string destPath, int destWidth, int destHeight)
        {
            var bitmap = new Bitmap(srcPath);
            return ResizeImage(bitmap, destPath, destWidth, destHeight);
        }

        public Size ResizeImage(Bitmap srcBitmap, string destPath, int destWidth, int destHeight)
        {
            var srcRect = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);
            return ResizeImage(srcBitmap, destPath, destWidth, destHeight, srcRect);
        }

        public Size ResizeImage(Bitmap srcBitmap, string destPath, int destWidth, int destHeight, Rectangle srcRect)
        {
            var outStream = new MemoryStream();
            var destBitmap = new Bitmap(destWidth, destHeight);

            destBitmap.SetResolution(72, 72);

            var g = Graphics.FromImage(destBitmap);
            g.Clear(Color.White);
            var destSize = new Size(destWidth, destHeight);
            var destRect = new Rectangle(Point.Empty, destSize);
            g.DrawImage(srcBitmap, destRect, srcRect, GraphicsUnit.Pixel);

            destBitmap.Save(destPath);
            return destSize;
        }
    }
}
