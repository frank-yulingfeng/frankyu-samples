
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public class RoundPanel : Panel
    {
        private int _cornerRadius = 0;
        /// <summary>
        /// 圆角半径
        /// </summary>
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value;
                SetRound();
            }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// 阴影
        /// </summary>
        public bool DropShadow { get; set; }

        public RoundPanel() : base()
        {
            ResizeRedraw = true;
        }       

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);           
            SetRound();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (BorderStyle != BorderStyle.None)
                return;

            var pen = new Pen(BorderColor, 0.5f);
            var rect = new Rectangle
            {
                Location = ClientRectangle.Location,
                Width = Width - 1,
                Height = Height - 1
            };
            //非圆角时，阴影才生效
            if (DropShadow && CornerRadius == 0)
            {
                rect.Width -= 4;
                rect.Height -= 4;
                DrawShadom(e.Graphics);
            }
            DrawRoundedRectangle(e.Graphics, new Pen(BorderColor, 0.5f), rect, CornerRadius);
        }

        private void DrawShadom(Graphics g)
        {
            // horizon line
            var pen = new Pen(Color.FromArgb(236, 236, 236), 0.5f);
            g.DrawLine(pen, new Point(0, Height - 4), new Point(Width, Height - 4));
            g.DrawLine(pen, new Point(0, Height - 3), new Point(Width, Height - 3));
            g.DrawLine(pen, new Point(0, Height - 2), new Point(Width, Height - 2));
            g.DrawLine(pen, new Point(0, Height - 1), new Point(Width, Height - 1));

            pen.Color = Color.FromArgb(213, 213, 213);
            g.DrawLine(pen, new Point(1, Height - 4), new Point(Width - 4, Height - 4));
            pen.Color = Color.FromArgb(223, 223, 223);
            g.DrawLine(pen, new Point(3, Height - 3), new Point(Width - 4, Height - 3));
            pen.Color = Color.FromArgb(230, 230, 230);
            g.DrawLine(pen, new Point(5, Height - 2), new Point(Width - 3, Height - 2));
            pen.Color = Color.FromArgb(236, 236, 236);
            g.DrawLine(pen, new Point(6, Height - 1), new Point(Width - 2, Height - 1));

            //verical line
            pen.Color = Color.FromArgb(236, 236, 236);
            g.DrawLine(pen, new Point(Width - 1, 0), new Point(Width - 1, Height));
            g.DrawLine(pen, new Point(Width - 2, 0), new Point(Width - 2, Height));
            g.DrawLine(pen, new Point(Width - 3, 0), new Point(Width - 3, Height));
            g.DrawLine(pen, new Point(Width - 4, 0), new Point(Width - 4, Height));

            pen.Color = Color.FromArgb(213, 213, 213);
            g.DrawLine(pen, new Point(Width - 4, 1), new Point(Width - 4, Height - 5));
            pen.Color = Color.FromArgb(223, 223, 223);
            g.DrawLine(pen, new Point(Width - 3, 3), new Point(Width - 3, Height - 4));
            pen.Color = Color.FromArgb(230, 230, 230);
            g.DrawLine(pen, new Point(Width - 2, 5), new Point(Width - 2, Height - 3));
            pen.Color = Color.FromArgb(236, 236, 236);
            g.DrawLine(pen, new Point(Width - 1, 6), new Point(Width - 1, Height - 2));
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

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
           (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse
           );

        private void SetRound()
        {
            var corerRadius = CornerRadius + (!BorderColor.IsEmpty ? 1 : 0);
            IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, corerRadius, corerRadius);
            Region = Region.FromHrgn(ptr);
        }
    }
}
