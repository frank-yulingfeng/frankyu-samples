using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mesince.Seal
{
    public static class CommonUtils
    {
        public static bool SaveImage(this Canvas canvas, string filename)
        {
            var stream = ConvertToStream(canvas);
            File.WriteAllBytes(filename, stream.ToArray());
            return true;
        }

        public static MemoryStream ConvertToStream(this Canvas canvas)
        {
            var renderBitmap = new RenderTargetBitmap(
                    (int)canvas.Width, (int)canvas.Height,
                    96d, 96d, PixelFormats.Pbgra32);
            canvas.Measure(new Size((int)canvas.Width, (int)canvas.Height));
            canvas.Arrange(new Rect(new Size((int)canvas.Width, (int)canvas.Height)));

            renderBitmap.Render(canvas);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            MemoryStream stream = new MemoryStream();
            encoder.Save(stream);

            return stream;
        }
    }
}
