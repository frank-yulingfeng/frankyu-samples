
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Mesince.Seal
{
    public class SignatureGenerator
    {
        public const string FONT_FAMILY_CN = "华文行楷";
        public const string FONT_FAMILY_EN = "Palace Script MT";

        public SignatureGenerator()
        {

        }

        public MemoryStream Generate(string signtrue, int fontSize, bool isChinese = true)
        {
            var canv = DrawOnCanvas(signtrue, fontSize, isChinese ? FONT_FAMILY_CN : FONT_FAMILY_EN);
            return canv.ConvertToStream();
        }

        public Canvas DrawOnCanvas(string signture, int fontSize, string fontFamily)
        {
            Canvas canv = new Canvas()
            {
                Width = 300,
                Height = 200
            };

            if (string.IsNullOrEmpty(signture))
                return canv;

            TextBlock txtBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment =VerticalAlignment.Center,
                TextAlignment= TextAlignment.Center,

                TextWrapping= TextWrapping.Wrap,
                
                Text = signture,
                FontFamily = new System.Windows.Media.FontFamily(fontFamily),
                FontSize = fontSize,
            };

            Label lbl = new Label
            {
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                MaxWidth = canv.Width - 20,
                MaxHeight = canv.Height - 20
            };
            lbl.Content = txtBlock;

            canv.Children.Add(lbl);

            lbl.Measure(new Size(double.MaxValue, double.MaxValue));
            var top = (canv.Height - lbl.DesiredSize.Height) / 2;
            var left = (canv.Width - lbl.DesiredSize.Width) / 2;

            Canvas.SetLeft(lbl, left);
            Canvas.SetTop(lbl, top);

            return canv;
        }

        public Canvas DrawOnCanvasAutoSize(string signture, int maxfontSize, string fontFamily)
        {
            if (string.IsNullOrEmpty(signture))
            {
                return new Canvas();
            }

            Label lbl = null;
            //循环检测
            while (true)
            {
                var templbl = GetLabel(signture, maxfontSize, fontFamily);
                if (templbl.DesiredSize.Width <= 450 || maxfontSize < 30)
                {
                    lbl = templbl;
                    break;
                }
                //如果过长，缩小两个像素，重新生成
                maxfontSize -= 2;
            }          

            var canv = new Canvas()
            {
                Width = lbl.DesiredSize.Width + 6,
                Height = lbl.DesiredSize.Height + 6
            };
            canv.Children.Add(lbl);
            var top = (canv.Height - lbl.DesiredSize.Height) / 2;
            var left = (canv.Width - lbl.DesiredSize.Width) / 2;

            Canvas.SetLeft(lbl, left);
            Canvas.SetTop(lbl, top);

            return canv;
        }

        private Label GetLabel(string signture, int fontSize, string fontFamily)
        {
            var txtBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center,

                TextWrapping = TextWrapping.Wrap,

                Text = signture,
                FontFamily = new System.Windows.Media.FontFamily(fontFamily),
                FontWeight = FontWeights.Bold,
                FontSize = fontSize,
            };

            Label lbl = new Label
            {
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                MaxWidth = int.MaxValue,
                MaxHeight = int.MaxValue,
            };
            lbl.Content = txtBlock;
            lbl.Measure(new Size(double.MaxValue, double.MaxValue));

            return lbl;
        }
    }
}
