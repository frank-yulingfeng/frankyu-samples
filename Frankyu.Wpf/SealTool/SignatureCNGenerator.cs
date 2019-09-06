
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// 中文个人章生成器
    /// </summary>
    public class SignatureCNGenerator
    {
        public const string SEAL_FONT_FAMILY = "楷体,宋体,黑体";
        public const string SEAL_FONT_FAMILY_1 = "隶书,黑体,楷体";

        public const int SEAL_TEXT_SIZE = 80;
        public const int SEAL_TEXT_SIZE_6 = 56;
        public const int SEAL_TEXT_SIZE_9 = 53;

        private Brush _textBrush = new SolidColorBrush(Colors.Red);

        public Canvas DrawOnCanvas(string sealText)
        {
            if (string.IsNullOrEmpty(sealText))
            {
                new Canvas()
                {
                    Width = 200,
                    Height = 200
                };
            }

            //10个字以内返回方章
            if (sealText.Length < 10)
            {
                return GenerateSquareSeal(sealText);
            }

            return GenerateSignature(sealText);

        }

        #region 正方形章

        /// <summary>
        /// 生成正方形章
        /// </summary>
        /// <returns></returns>
        public Canvas GenerateSquareSeal(string sealText)
        {
            Canvas canv = new Canvas()
            {
                Width = 200,
                Height = 200
            };

            //外圈
            var rect = new Rectangle()
            {
                Width = 200,
                Height = 200,
                Stroke = _textBrush,
                StrokeThickness = 6,
            };

            Canvas.SetLeft(rect, 0);
            Canvas.SetTop(rect, 0);
            canv.Children.Add(rect);

            var rect1 = new Rectangle()
            {
                Width = 182,
                Height = 182,
                Stroke = _textBrush,
                StrokeThickness = 2,
            };
            Canvas.SetLeft(rect1, 9);
            Canvas.SetTop(rect1, 9);
            canv.Children.Add(rect1);

            bool customAdd = false;
            //奇数加 印 字
            if ((sealText.Length == 2 || sealText.Length == 8 || sealText.Length % 2 == 1) && sealText.Length < 9)
            {
                sealText = sealText + "印";
                customAdd = true;
            }

            int index = 1;
            var length = sealText.Length;
            var fontSize = SEAL_TEXT_SIZE;
            if (length > 4 && length < 7)
            {
                fontSize = SEAL_TEXT_SIZE_6;
            }
            if (length >= 7 && length < 10)
            {
                fontSize = SEAL_TEXT_SIZE_9;
            }

            foreach (var word in sealText)
            {
                var fontFamily = SEAL_FONT_FAMILY;
                if (customAdd && index == length)//最后一个印字，字体特殊处理
                {
                    fontFamily = SEAL_FONT_FAMILY_1;
                }

                var txtBlock = GetTextBlock(word.ToString(), fontSize, fontFamily);
                Point location = new Point(0, 0);

                if (length < 5)
                    location = GetLocation4(index, txtBlock, length);
                else if (length < 7)
                    location = GetLocation6(index, txtBlock, 178, 11);
                else
                    location = GetLocation9(index, txtBlock, 178, 11);

                Canvas.SetLeft(txtBlock, location.X);
                Canvas.SetTop(txtBlock, location.Y);
                canv.Children.Add(txtBlock);

                index++;
            }

            return canv;
        }

        /// <summary>
        /// 四个格子
        /// </summary>
        /// <returns></returns>
        private Point GetLocation4(int index, TextBlock textBlock, int length)
        {
            Point point = new Point(0, 0);
            double wordWidth = textBlock.DesiredSize.Width;
            double wordHeight = textBlock.DesiredSize.Height;
            //每个方块 90*90
            if (index == 1)
            {
                //左上点（100，10）
                point.X = 100 + (90 - wordWidth) / 2 - 5;
                point.Y = 10 + (90 - wordHeight) / 2 + 5;
            }
            if (index == 2)
            {
                //左上点（100，100）
                point.X = 100 + (90 - wordWidth) / 2 - 5;
                point.Y = 100 + (90 - wordHeight) / 2 - 5;
            }
            if (index == 3)
            {
                //左上点（10，10）
                if (length == 3)
                {
                    //左上点（10，10）
                    point.X = 15 + (90 - wordWidth) / 2;
                    point.Y = 10 + (180 - wordHeight) / 2;
                }
                else
                {
                    //左上点（10，10）
                    point.X = 10 + (90 - wordWidth) / 2 + 5;
                    point.Y = 10 + (90 - wordHeight) / 2 + 5;
                }

            }
            if (index == 4)
            {
                //左上点（10，100）
                point.X = 10 + (90 - wordWidth) / 2 + 5;
                point.Y = 100 + (90 - wordHeight) / 2 - 5;
            }
            return point;
        }

        /// <summary>
        /// 六个格子
        /// </summary>
        /// <returns></returns>
        private Point GetLocation6(int index, TextBlock textBlock, double sideLength, double offset = 0)
        {
            Point point = new Point(offset, offset);
            double wordAreaWidth = sideLength / 2;
            double wordAreaHeight = sideLength / 3;

            if (index == 1)
            {
                point.X += wordAreaWidth - 10;
            }
            if (index == 2)
            {
                point.X += wordAreaWidth - 10;
                point.Y += wordAreaHeight;
            }
            if (index == 3)
            {
                point.X += wordAreaWidth - 10;
                point.Y += wordAreaHeight * 2;
            }

            if (index == 4)
            {
                point.X += 10;
            }
            if (index == 5)
            {
                point.X += 10;
                point.Y += wordAreaHeight;
            }
            if (index == 6)
            {
                point.X += 10;
                point.Y += wordAreaHeight * 2;
            }
            
            double wordWidth = textBlock.DesiredSize.Width;
            double wordHeight = textBlock.DesiredSize.Height;
            point.X += (wordAreaWidth - wordWidth) / 2;
            point.Y += (wordAreaHeight - wordHeight) / 2;
            return point;
        }

        /// <summary>
        /// 9个格子
        /// </summary>
        /// <returns></returns>
        private Point GetLocation9(int index, TextBlock textBlock, double sideLength, double offset = 0)
        {
            Point point = new Point(offset, offset);
            double wordAreaWidth = sideLength / 3;
            double wordAreaHeight = sideLength / 3;
            if (index == 1)
            {
                point.X += wordAreaWidth * 2;
            }
            if (index == 2)
            {
                point.X += wordAreaWidth * 2;
                point.Y += wordAreaHeight;
            }
            if (index == 3)
            {
                point.X += wordAreaWidth * 2;
                point.Y += wordAreaHeight * 2;
            }

            if (index == 4)
            {
                point.X += wordAreaWidth;
            }
            if (index == 5)
            {
                point.X += wordAreaWidth;
                point.Y += wordAreaHeight;
            }
            if (index == 6)
            {
                point.X += wordAreaWidth;
                point.Y += wordAreaHeight * 2;
            }

            if (index == 7)
            {
            }
            if (index == 8)
            {
                point.Y += wordAreaHeight;
            }
            if (index == 9)
            {
                point.Y += wordAreaHeight * 2;
            }

            double wordWidth = textBlock.DesiredSize.Width;
            double wordHeight = textBlock.DesiredSize.Height;
            point.X += (wordAreaWidth - wordWidth) / 2;
            point.Y += (wordAreaHeight - wordHeight) / 2;
            return point;
        }

        private TextBlock GetTextBlock(string word, int fontSize, string fontFamily)
        {
            var wordBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                TextWrapping = TextWrapping.Wrap,

                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily(fontFamily),
                FontSize = fontSize,
                Foreground = _textBrush,
                Text = word,
            };
            wordBlock.Measure(new Size(double.MaxValue, double.MaxValue));
            return wordBlock;
        }

        #endregion

        #region 签名

        public Canvas GenerateSignature(string sealText)
        {
            var maxfontSize = SEAL_TEXT_SIZE;

            Label lbl = null;
            //循环检测
            while (true)
            {
                var templbl = GetLabel(sealText, maxfontSize);
                if (templbl.DesiredSize.Width <= 450 || maxfontSize <= 10)
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

        private Label GetLabel(string signture, int fontSize)
        {
            var txtBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily(SEAL_FONT_FAMILY),
                FontWeight = FontWeights.Bold,
                FontSize = fontSize,
                Text = signture
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

        #endregion
    }
}
