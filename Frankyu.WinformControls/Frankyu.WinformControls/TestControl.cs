using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Frankyu.WinformControls
{
    public partial class TestControl : UserControl
    {
        const int RED_REGION_WIDTH = 16;

        public TestControl()
        {
            InitializeComponent();
            base.BackColor = Color.Transparent;      
        }

        bool isMouseOver = false;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (IsRedRegion())
            {
                Cursor = Cursors.Hand;
                isMouseOver = true;
            }
            else
            {
                isMouseOver = false;
            }           
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (IsRedRegion())
            {
                if (!isMouseOver)
                {
                    Cursor = Cursors.Hand;
                    isMouseOver = true;
                }
            }
            else
            {
                if (isMouseOver)
                {
                    isMouseOver = false;
                    Cursor = Cursors.Default;
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
            isMouseOver = false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (IsRedRegion())
            {
                //MessageBox.Show("You Click Me");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            //画背景
            var rect = new Rectangle
            {
                Location = new Point(0, (RED_REGION_WIDTH / 2) - 1),
                Size = new Size(Width - RED_REGION_WIDTH / 2, Height - RED_REGION_WIDTH / 2)
            };
            var rect1 = new Rectangle
            {
                Location = new Point(1, (RED_REGION_WIDTH / 2)),
                Size = new Size(Width - RED_REGION_WIDTH / 2 - 1, Height - RED_REGION_WIDTH / 2 - 1)
            };
            e.Graphics.FillRectangle(new SolidBrush(BackColor), rect1);
            DrawRoundedRectangle(e.Graphics, new Pen(BorderColor == Color.Transparent ? BackColor : BorderColor), rect, 3);

            //画数据
            e.Graphics.DrawImage(Properties.Resources.remove, new Rectangle
            {
                Location = new Point(Width - RED_REGION_WIDTH, 0),
                Size = new Size(RED_REGION_WIDTH, RED_REGION_WIDTH)
            });

            e.Graphics.DrawString("CustomLabel", Font, Brushes.Black, rect, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
            });
        }

        private Color _borderColor = Color.Transparent;
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        private Color _backColor = Color.Transparent;
        public new Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
            }
        }


        private GraphicsPath GetGraphPath(Rectangle rect, int cRadius)
        {
            // 要实现 圆角化的 矩形  
            // 指定图形路径， 有一系列 直线/曲线 组成
            var myPath = new GraphicsPath();
            myPath.StartFigure();
            myPath.AddArc(new Rectangle(new Point(rect.X, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 180, 90);
            myPath.AddLine(new Point(rect.X + cRadius, rect.Y), new Point(rect.Right - cRadius, rect.Y));
            myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 270, 90);
            myPath.AddLine(new Point(rect.Right, rect.Y + cRadius), new Point(rect.Right, rect.Bottom - cRadius));
            myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 0, 90);
            myPath.AddLine(new Point(rect.Right - cRadius, rect.Bottom), new Point(rect.X + cRadius, rect.Bottom));
            myPath.AddArc(new Rectangle(new Point(rect.X, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 90, 90);
            myPath.AddLine(new Point(rect.X, rect.Bottom - cRadius), new Point(rect.X, rect.Y + cRadius));
            myPath.CloseFigure();

            return myPath;
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;

            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            //左上角   
            path.AddArc(arcRect, 180, 90);

            //右上角   
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            //右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            //左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        private bool IsRedRegion()
        {
            var p = PointToClient(MousePosition);
            if (p.X > (Width - RED_REGION_WIDTH) && p.Y < RED_REGION_WIDTH)
                return true;
            else
                return false;
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();
            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }
            // top left arc
            path.AddArc(arc, 180, 90);
            // top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            // bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (pen == null)
                throw new ArgumentNullException("pen");
            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        public static void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (brush == null)
                throw new ArgumentNullException("brush");
            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.FillPath(brush, path);
            }
        }
    }

}
