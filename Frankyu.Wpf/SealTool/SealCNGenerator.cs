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
    /// 中文图章生成器
    /// </summary>
    public class SealCNGenerator
    {
        public const string SEAL_TYPE = "电子公章";
        public const string SEAL_FONT_FAMILY = "宋体,黑体";
        public const int SEAL_TEXT_SIZE = 30;
        public const int SEAL_TYPE_SIZE = 25;

        private Brush _textBrush = new SolidColorBrush(Colors.Red);

        //public MemoryStream Generate(string orgName)
        //{
        //    var canvas = DrawOnCanvas(orgName);
        //    return canvas.ConvertToStream();
        //}

        public Canvas DrawOnCanvas(string sealText, string sealType)
        {
            Canvas canv = new Canvas()
            {
                Width = 237,
                Height = 237
            };

            if (string.IsNullOrEmpty(sealText))
                return canv;

            //外圈
            var ellipse = new Ellipse()
            {
                Width = 235,
                Height = 235,
                Stroke = _textBrush,
                StrokeThickness = 5,
            };
            Canvas.SetLeft(ellipse, 1);
            Canvas.SetTop(ellipse, 1);
            canv.Children.Add(ellipse);

            //画图章名称 公司名
            DrawSealText(canv, sealText);

            //画图章类型
            DrawSealType(canv, string.IsNullOrEmpty(sealType) ? SEAL_TYPE : sealType);

            //画五角星
            DrawFivePointStar(canv);

            return canv;
        }

        /// <summary>
        /// 画出图章内容
        /// </summary>
        /// <param name="canv"></param>
        /// <param name="sealText"></param>
        private void DrawSealText(Canvas canv, string sealText)
        {
            double totalAngle = 236.0;
            double fontSize = SEAL_TEXT_SIZE;
            double startAngle = -110;
            double endAngle = 123;
            var scale = 0.8;
            var offset = 0;

            //太长了要减小字体
            if (sealText.Length >= 15)
            {
                scale = 0.7;
                offset = 2;
            }
            if (sealText.Length >= 20)
            {
                scale = 0.6;
                offset = 4;
            }

            if (sealText.Length <= 9)
            {
                startAngle = -105;
                endAngle = 110;
            }
            if (sealText.Length <= 6)
            {
                startAngle = -100;
                endAngle = 100;
            }

            fontSize -= offset;
            int i = 0;
            double angleAdd = totalAngle / sealText.Length;
            for (double angle = startAngle; angle < endAngle; angle += angleAdd)
            {
                //字体旋转
                TransformGroup tfGroup = new TransformGroup();
                var st = new ScaleTransform(scale, 1);//字体大小，间隔
                var tt = new TranslateTransform(0, -109);//这是半径
                var rtf = new RotateTransform(angle);
                tfGroup.Children.Add(st);
                tfGroup.Children.Add(tt);
                tfGroup.Children.Add(rtf);

                var word = new TextBlock()
                {
                    RenderTransformOrigin = new Point(0.5, 0),
                    Foreground = _textBrush,
                    FontFamily = new FontFamily(SEAL_FONT_FAMILY),
                    FontWeight = FontWeights.Bold,
                    FontSize = fontSize,
                    Text = sealText[i++].ToString(),
                    RenderTransform = tfGroup,
                };
                canv.Children.Add(word);
                Canvas.SetTop(word, 125 - 9);
                Canvas.SetLeft(word, 112 - 9);
            }
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
                FontSize = SEAL_TYPE_SIZE,
                Text = sealType,
            };
            canv.Children.Add(type);

            type.Measure(new Size(canv.Height, canv.Height));
            var size = type.DesiredSize;

            var left = (canv.Height - size.Width) / 2;
            var top = canv.Height / 2 + 55;

            Canvas.SetTop(type, top);
            Canvas.SetLeft(type, left);
        }

        /// <summary>
        /// 画五角星
        /// </summary>
        private void DrawFivePointStar(Canvas canv)
        {
            int radius = 45;

            Polygon plg = new Polygon();
            plg.Points = GetFivePoint1(new Point(), radius);
            plg.Stroke = Brushes.Transparent;
            plg.StrokeThickness = 2;
            plg.Fill = _textBrush;
            plg.FillRule = FillRule.Nonzero;
            canv.Children.Add(plg);

            Canvas.SetTop(plg, (canv.Height - radius * 2) / 2 - 5);
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

        /// <summary>
        ///第二种画法 根据半径和圆心确定十个点
        /// </summary>
        /// <param name="center"></param>
        /// <returns></returns>
        private PointCollection GetFivePoint2(Point center, double r)
        {
            int i;

            //两个圆的半径 和第一个点初始角度
            //r1 = r / 2.5, r2 = r值的互换确定是正五角星还是倒五角星
            double r1 = r / 2.5, r2 = r, g = 18;
            double pi = Math.PI;
            List<Point> values = new List<Point>(10);//十个点
            List<Point> values1 = new List<Point>(5);//(内)外接五个点
            List<Point> values2 = new List<Point>(5);//(外)内接五个点
            for (i = 0; i < 5; i++)
            {
                //计算10个点的坐标
                Point p1 = new Point(r1 * Math.Cos(g * pi / 180), r1 * Math.Sin(g * pi / 180));
                Point p2 = new Point(r2 * Math.Cos((g + 36) * pi / 180), r2 * Math.Sin((g + 36) * pi / 180));
                values1.Add(p1);
                values2.Add(p2);
                g += 72;
            }
            //左半边：3,4,5,6,7,8
            //右半边：1,2,3,8,9,10
            values.Add(values1[0]);//1
            values.Add(values2[0]);//2
            values.Add(values1[1]);//3
            values.Add(values2[1]);//4
            values.Add(values1[2]);//5
            values.Add(values2[2]);//6
            values.Add(values1[3]);//7
            values.Add(values2[3]);//8
            values.Add(values1[4]);//9
            values.Add(values2[4]);//10

            PointCollection pcollect = new PointCollection(values);
            return pcollect;
        }
    }
}
