using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Frankyu.WinformControls
{
    public partial class CustomLabel : UserControl
    {
        public event EventHandler ImageClick;

        int _borderRadius = 0;

        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                _borderRadius = value;
                Invalidate();
            }
        }

        public CustomLabel()
        {
            InitializeComponent();
            Text = "CustomLabel";
            ResizeRedraw = true;           
            SetRound(lbl);
            lbl.Paint += Lbl_Paint;
            lbl.Resize += Lbl_Resize;
            img.Click += Img_Click;
            Invalidate();
        }

        private void Lbl_Resize(object sender, EventArgs e)
        {
            lbl.Invalidate();
        }

        private void Lbl_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.LightGray, 0.5f);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;//消除锯齿
            //DrawRoundRect(e.Graphics, pen, new Point(0, 0), lbl.ClientRectangle.Width - 1, lbl.ClientRectangle.Height - 1, BorderRadius);

            var rect = new Rectangle
            {
                Location = lbl.ClientRectangle.Location,
                Size = lbl.Size - new Size(1, 1)
            };

            DrawRoundedRectangle(e.Graphics, pen, rect, BorderRadius);            
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        private void Img_Click(object sender, EventArgs e)
        {
            if (ImageClick != null)
                ImageClick.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            lbl.Font = Font;
            AutoMeasureSize();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            lbl.Text = Text;

            AutoMeasureSize();
        }

        private void AutoMeasureSize()
        {
            var g = CreateGraphics();
            var size = g.MeasureString(Text, Font);
            var width = size.Width + 50;
            if (width > Width)
            {
                Width = (int)width;               
            }

            var height = size.Height + 25;
            if (height > Height)
            {
                Height = (int)height;               
            }
            Invalidate();
        }

        ///// <summary>
        ///// 画圆角矩形
        ///// </summary>
        ///// <param name="g"></param>
        ///// <param name="pen"></param>
        ///// <param name="point"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="radius"></param>
        //public static void DrawRoundRect(Graphics g,
        //    Pen pen, Point point,
        //    int width, int height, int radius = 0)
        //{
        //    //圆角半径不能大于长或宽的一半
        //    if (radius > width / 2 || radius > height / 2)
        //        radius = 0;

        //    var size = new Size(radius * 2, radius * 2);

        //    var pLeftUp = point;
        //    var pLeftDown = point + new Size(0, height);
        //    var pRightUp = point + new Size(width, 0);
        //    var pRightDown = point + new Size(width, height);

        //    //画出一个大的矩形
        //    g.DrawLine(pen, pLeftUp.X, pLeftUp.Y + radius, pLeftDown.X, pLeftDown.Y - radius);
        //    g.DrawLine(pen, pLeftUp.X + radius, pLeftUp.Y, pRightUp.X - radius, pRightUp.Y);
        //    g.DrawLine(pen, pRightDown.X, pRightDown.Y - radius, pRightUp.X, pRightUp.Y + radius);
        //    g.DrawLine(pen, pRightDown.X - radius, pRightDown.Y, pLeftDown.X + radius, pLeftDown.Y);

        //    if (radius == 0)
        //        return;

        //    //画四个圆角
        //    var rect1 = new Rectangle(pLeftUp, size);
        //    g.DrawArc(pen, rect1, 180, 90);
        //    var rect2 = new Rectangle(new Point(pLeftDown.X, pLeftDown.Y - size.Width), size);
        //    g.DrawArc(pen, rect2, 90, 90);
        //    var rect3 = new Rectangle(new Point(pRightUp.X - size.Width, pRightUp.Y), size);
        //    g.DrawArc(pen, rect3, 270, 90);
        //    var rect4 = new Rectangle(new Point(pRightDown.X - size.Width, pRightDown.Y - size.Width), size);
        //    g.DrawArc(pen, rect4, 0, 90);
        //}

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

        /// <summary>
        /// 设置圆形
        /// </summary>
        private void SetRound(Control contol)
        {
            IntPtr ptr = CreateRoundRectRgn(0, 0, contol.Width, contol.Height, BorderRadius, BorderRadius);
            contol.Region = Region.FromHrgn(ptr);
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

        private void lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
