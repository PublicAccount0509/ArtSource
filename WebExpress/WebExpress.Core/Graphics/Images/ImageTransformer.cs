using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public class ImageTransformer
    {
        public static readonly ImageTransformer Instance = new ImageTransformer();
        private ImageTransformer()
        {

        }

        public void ResizeImageToWidth(string srcPath, string destPath, int destWidth)
        {
            var bitmap = new Bitmap(srcPath);
            var srcWidth = bitmap.Width;
            var srcHeight = bitmap.Height;

            double factor = (double)destWidth / srcWidth;
            var destHeight = (int)(srcHeight * factor);

            ResizeImage(bitmap, destPath, destWidth, destHeight);
        }

        public void ResizeImageToWidth(string srcPath, string destPath, int destWidth, int minHeight)
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
            ResizeImage(bitmap, destPath, destWidth, destHeight, srcRect);
        }

        public void ResizeImageToHeight(string srcPath, string destPath, int destHeight)
        {
            var bitmap = new Bitmap(srcPath);
            var srcWidth = bitmap.Width;
            var srcHeight = bitmap.Height;

            double factor = (double)destHeight / srcHeight;
            var destWidth = (int)(srcWidth * factor);

            ResizeImage(bitmap, destPath, destWidth, destHeight);
        }

        public void ResizeImageToSize(string srcPath, string destPath, int destWidth, int destHeight)
        {
            var bitmap = new Bitmap(srcPath);
            var srcWidth = bitmap.Width;
            var srcHeight = bitmap.Height;

            double factorWidth = (double)destWidth / srcWidth;
            double factorHeight = (double)destHeight / srcHeight;
            var invalidFactor = Math.Pow(factorWidth, factorHeight);
            Rectangle srcRect;
            if (factorWidth > factorHeight)
            {
                var validHeight = (int)(destHeight / invalidFactor);
                var redundantHeight = srcHeight - validHeight;
                srcRect = new Rectangle(0, redundantHeight / 2, destWidth, srcHeight);
            }
            else
            {
                var validWidth = (int)(destWidth / invalidFactor);
                var redundantHeight = srcWidth - validWidth;
                srcRect = new Rectangle(redundantHeight / 2, 0, destWidth, srcHeight);
            }

            ResizeImage(bitmap, destPath, destWidth, destHeight, srcRect);
        }

        public void ResizeImage(string srcPath, string destPath, int destWidth, int destHeight)
        {
            var bitmap = new Bitmap(srcPath);
            ResizeImage(bitmap, destPath, destWidth, destHeight);
        }

        public void ResizeImage(Bitmap srcBitmap, string destPath, int destWidth, int destHeight)
        {
            var srcRect = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);
            ResizeImage(srcBitmap, destPath, destWidth, destHeight, srcRect);
        }

        public void ResizeImage(Bitmap srcBitmap, string destPath, int destWidth, int destHeight, Rectangle srcRect)
        {
            System.IO.MemoryStream outStream = new System.IO.MemoryStream();
            Bitmap destBitmap = new Bitmap(destWidth, destHeight);

            destBitmap.SetResolution(72, 72);

            Graphics g = Graphics.FromImage(destBitmap);
            g.Clear(Color.White);
            var destRect = new Rectangle(0, 0, destWidth, destHeight);
            g.DrawImage(srcBitmap, destRect, srcRect, GraphicsUnit.Pixel);

            destBitmap.Save(destPath);
        }
    }
}
