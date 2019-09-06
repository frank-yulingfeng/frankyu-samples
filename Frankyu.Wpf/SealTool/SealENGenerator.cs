using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Mesince.Seal
{
    /// <summary>
    /// 英文图章生成器
    /// </summary>
    public class SealENGenerator
    {
        public const string SEAL_FONT_FAMILY = "Arial";
        public const int SEAL_TEXT_SIZE = 25;

        public const int SEAL_ORG_SIZE = 22;
        public const int SEAL_STATE_SIZE = 15;

        public const string STR_ORGANIZATION = "ORGANIZATION";

        private Brush _textBrush = new SolidColorBrush(Color.FromRgb(85, 91, 161));

        public SealENGenerator()
        {

        }

        //public MemoryStream Generate(string orgName, string location)
        //{
        //    var canvas = DrawOnCanvas(orgName, location);
        //    return canvas.ConvertToStream();
        //}

        public Canvas DrawOnCanvas(string sealText, string sealType, string location = "")
        {
            Canvas canv = new Canvas()
            {
                Width = 237,
                Height = 237
            };

            if (string.IsNullOrEmpty(sealText))
                return canv;

            //外圈
            int ellipseSize = 235;
            var ellipse = new Ellipse()
            {
                Width = ellipseSize,
                Height = ellipseSize,
                Stroke = _textBrush,
                StrokeThickness = 5,
            };
            var padding = (canv.Width - ellipseSize) / 2;
            Canvas.SetLeft(ellipse, padding);
            Canvas.SetTop(ellipse, padding);
            canv.Children.Add(ellipse);

            //内圈
            int sizeSmall = 155;
            var ellipseSmall = new Ellipse()
            {
                Width = sizeSmall,
                Height = sizeSmall,
                Stroke = _textBrush,
                StrokeThickness = 3,
            };

            padding = (canv.Width - sizeSmall) / 2;
            Canvas.SetLeft(ellipseSmall, padding);
            Canvas.SetTop(ellipseSmall, padding);
            canv.Children.Add(ellipseSmall);

            DrawSealType(canv, sealType);

            ////画图章名称 公司名
            double totalAngle = 0;
            double startAngle = 0;
            double doubleSize = SEAL_ORG_SIZE;
            CalcOrgText(sealText.Length, ref doubleSize, ref totalAngle, ref startAngle);
            DrawTopText(canv, sealText.ToUpperInvariant(), 95, doubleSize, totalAngle, startAngle);

            DrawFivePointStar(canv);

            //DrawTopText(canv, STR_ORGANIZATION, 63, SEAL_STATE_SIZE, 120, -55);

            //位置
            //if (!string.IsNullOrEmpty(location))
            //{
            //    doubleSize = SEAL_STATE_SIZE;
            //    CalcStateText(location.Length, ref doubleSize, ref totalAngle, ref startAngle);
            //    DrawBottomText(canv, location.ToUpperInvariant(), 63, doubleSize, totalAngle, startAngle);
            //}

            return canv;
        }

        private void CalcStateText(int length, ref double doubleSize, ref double totalAngle, ref double startAngle)
        {
            totalAngle = 90;
            startAngle = 0;

            int sizeM = 0;
            if (length >= 10)
            {
                totalAngle = 120;
                sizeM = 1;
            }
            if (length >= 15)
            {
                totalAngle = 140;
                sizeM = 2;
            }
            if (length >= 20)
            {
                totalAngle = 180;
                sizeM = 2;
            }
            if (length >= 25)
            {
                totalAngle = 210;
                sizeM = 3;
            }
            if (length >= 30)
            {
                totalAngle = 230;
                sizeM = 4;
            }

            doubleSize -= sizeM;
            startAngle = -(totalAngle / 2 - 5);
        }

        private void CalcOrgText(int length, ref double doubleSize, ref double totalAngle, ref double startAngle)
        {
            totalAngle = 120;
            startAngle = 0;

            int sizeM = 0;
            if (length >= 10)
            {
                totalAngle = 180;
                sizeM = 1;
            }
            if (length >= 20)
            {
                totalAngle = 220;
                sizeM = 2;
            }
            if (length >= 25)
            {
                totalAngle = 240;
                sizeM = 3;
            }
            if (length >= 30)
            {
                totalAngle = 270;
                sizeM = 4;
            }
            if (length >= 40)
            {
                totalAngle = 320;
                sizeM = 5;
            }

            doubleSize -= sizeM;
            startAngle = -(totalAngle / 2 - 8);
        }


        /// <summary>
        /// 画出图章类型
        /// </summary>
        /// <param name="canv"></param>
        /// <param name="sealType"></param>
        private void DrawSealType(Canvas canv, string sealType)
        {
            var type = new TextBlock()
            {
                Foreground = _textBrush,
                FontFamily = new FontFamily(SEAL_FONT_FAMILY),
                FontWeight = FontWeights.Bold,
                FontSize = SEAL_TEXT_SIZE,
                Text = string.IsNullOrEmpty(sealType) ? "SEAL" : sealType,
            };
            canv.Children.Add(type);

            type.Measure(new Size(canv.Height, canv.Height));
            var size = type.DesiredSize;

            var left = (canv.Height - size.Width) / 2;
            var top = (canv.Height - size.Height) / 2;

            Canvas.SetTop(type, top);
            Canvas.SetLeft(type, left);
        }

        private void DrawTopText(Canvas canv, string words, 
            double radius,double fontSize,
            double totalAngle, double startAngle)
        {
            double cx = canv.Width / 2;
            double cy = canv.Height / 2;
            double angleAdd = totalAngle / words.Length;

            int num_angles = words.Length;
            int index = 0;
            foreach (var word in words)
            {
                double angle = startAngle + index++ * angleAdd;

                // Math.Sin and Math.Cos use radians.
                double radians = (angle - 90) / 180 * Math.PI;
                double x = cx + radius * Math.Cos(radians);
                double y = cy + radius * Math.Sin(radians);

                // Use theta for the text, not angle.
                string text = word.ToString();

                // Draw the text.
                DrawText(canv, text,
                    new Point(x, y), angle, fontSize,
                    HorizontalAlignment.Center,
                    VerticalAlignment.Center);
            }
        }

        private void DrawBottomText(Canvas canv, string words,
            double radius, double fontSize,
            double totalAngle, double startAngle)
        {            
            char[] arr = words.ToCharArray();         // 转为字符数组
            Array.Reverse(arr);                  // 将数组反转
            words = new String(arr);

            double cx = canv.Width / 2;
            double cy = canv.Height / 2;
            double angleAdd = totalAngle / words.Length;

            int num_angles = words.Length;
            int index = 0;
            foreach (var word in words)
            {
                double angle = startAngle + index++ * angleAdd;

                // Math.Sin and Math.Cos use radians.
                double radians = (angle + 90) / 180 * Math.PI;
                double x = cx + radius * Math.Cos(radians);
                double y = cy + radius * Math.Sin(radians);

                // Use theta for the text, not angle.
                string text = word.ToString();

                // Draw the text.
                DrawText(canv, text,
                    new Point(x, y), angle, fontSize,
                    HorizontalAlignment.Center,
                    VerticalAlignment.Center);
            }
        }

        // Position a label at the indicated point.
        private void DrawText(Canvas can, string text,
            Point location, double angle, double font_size,
            HorizontalAlignment halign, VerticalAlignment valign)
        {
            // Make the label.
            Label label = new Label();
            label.Content = text;
            label.FontSize = font_size;
            label.FontWeight = FontWeights.Bold;
            label.Foreground = _textBrush;
            label.FontFamily = new FontFamily(SEAL_FONT_FAMILY);
            label.HorizontalAlignment = HorizontalAlignment.Center;            
            can.Children.Add(label);

            TransformGroup tfGroup = new TransformGroup();
            ScaleTransform st = new ScaleTransform(1, 1);
            // Rotate if desired.
            if (angle != 0)
                //label.LayoutTransform = new RotateTransform(angle);
                tfGroup.Children.Add(new RotateTransform(angle));

            tfGroup.Children.Add(st);
            label.LayoutTransform = tfGroup;

            // Position the label.
            label.Measure(new Size(double.MaxValue, double.MaxValue));

            double x = location.X;
            if (halign == HorizontalAlignment.Center)
                x -= label.DesiredSize.Width / 2;
            else if (halign == HorizontalAlignment.Right)
                x -= label.DesiredSize.Width;
            Canvas.SetLeft(label, x);

            double y = location.Y;
            if (valign == VerticalAlignment.Center)
                y -= label.DesiredSize.Height / 2;
            else if (valign == VerticalAlignment.Bottom)
                y -= label.DesiredSize.Height;
            Canvas.SetTop(label, y);

            // Uncomment the following code to see
            // the Label's bounding rectangle.
            //Rectangle rect = new Rectangle();
            //rect.Width = label.DesiredSize.Width;
            //rect.Height = label.DesiredSize.Height;
            //rect.StrokeThickness = 1;
            //rect.Stroke = Brushes.Red;
            //can.Children.Add(rect);
            //Canvas.SetLeft(rect, x);
            //Canvas.SetTop(rect, y);
        }

        /// <summary>
        /// 画五角星
        /// </summary>
        private void DrawFivePointStar(Canvas canv)
        {
            int radius = 12;

            Polygon plg = new Polygon();
            plg.Points = GetFivePoint1(new Point(), radius);
            plg.Stroke = Brushes.Transparent;
            plg.StrokeThickness = 2;
            plg.Fill = _textBrush;
            plg.FillRule = FillRule.Nonzero;
            canv.Children.Add(plg);

            Canvas.SetTop(plg, (canv.Height - radius * 2) / 2 + 96);
            Canvas.SetLeft(plg, (canv.Width - radius * 2) / 2);
        }

        /// <summary>
        ///第一种画法 根据半径和圆心确定五个点
        /// </summary>
        /// <param name="center"></param>
        /// <returns></returns>
        private PointCollection GetFivePoint1(Point center, double r)
        {
            double h1 = r * Math.Sin(18 * Math.PI / 180);
            double h2 = r * Math.Cos(18 * Math.PI / 180);
            double h3 = r * Math.Sin(36 * Math.PI / 180);
            double h4 = r * Math.Cos(36 * Math.PI / 180);
            Point p1 = new Point(r, center.X);
            Point p2 = new Point(r - h2, r - h1);
            Point p3 = new Point(r - h3, r + h4);
            Point p4 = new Point(r + h3, p3.Y);
            Point p5 = new Point(r + h2, p2.Y);
            List<Point> values = new List<Point>() { p1, p3, p5, p2, p4 };
            PointCollection pcollect = new PointCollection(values);
            return pcollect;
        }
    }
}
