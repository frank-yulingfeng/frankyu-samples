using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Frankyu.WinformControls
{
    public partial class SelectionCard : UserControl
    {
        private readonly Color Color_Default = Color.LightGray;

        private int _imageWidth = 30;
        /// <summary>W
        /// 图片宽度
        /// </summary>
        public int ImageWidth
        {
            get
            {
                return _imageWidth;
            }
            set
            {
                if (value != _imageWidth)
                {
                    _imageWidth = value;
                    img.Width = img.Height = value;
                    ReLocaiton();
                }
            }
        }

        /// <summary>
        /// 图片
        /// </summary>
        public Image Image
        {
            get
            {
                return img.Image;
            }
            set
            {
                img.Image = value;
            }
        }

        private bool _isSelected = false;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                img.Image = _isSelected ? Properties.Resources._checked : Properties.Resources._unchecked;
            }
        }

        private int _paddingLeft = 25;
        public int PaddingLeft
        {
            get { return _paddingLeft; }
            set
            {
                _paddingLeft = value;
                ReLocaiton();
            }
        }

        public SelectionCard()
        {
            _borderColor = Color_Default;
            InitializeComponent();
            ResizeRedraw = true;
            IsSelected = false;
            BorderWidth = 0.5f;
            ReLocaiton();

            //控件触发事件
            img.Click += (s, e) => 
            {
                this.InvokeOnClick(this, e); 
            };
            lbl.Click += (s, e) => 
            {
                this.InvokeOnClick(this, e);
            };
        }
        
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            lbl.Font = Font;
            ReLocaiton();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (BorderWidth <= 0)
                return;

            Pen pen = new Pen(BorderColor, BorderWidth);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;//消除锯齿
            DrawRoundRect(e.Graphics, pen, new Point(0, 0), Width - 1, Height - 1, BorderRadius);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ReLocaiton();
            Invalidate();
        }

        /// <summary>
        /// 重新定位控件位置
        /// </summary>
        private void ReLocaiton()
        {
            var left = PaddingLeft;
            var controlPadding = 10;

            img.Location = new Point(left, (Height - img.Height) / 2);

            lbl.Location = new Point(left + img.Width + controlPadding, (Height - lbl.Height) / 2);
        }

        private int _borderRadius = 0;
        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                _borderRadius = value;
                SetRound();
            }
        }

        private float _borderWidth = 0;
        public float BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }

        private Color _borderColor;

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 画圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="point"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void DrawRoundRect(Graphics g,
            Pen pen, Point point,
            int width, int height, int radius = 0)
        {
            //圆角半径不能大于长或宽的一半
            if (radius > width / 2 || radius > height / 2)
                radius = 0;

            var size = new Size(radius * 2, radius * 2);

            var pLeftUp = point;
            var pLeftDown = point + new Size(0, height);
            var pRightUp = point + new Size(width, 0);
            var pRightDown = point + new Size(width, height);

            //画出一个大的矩形
            g.DrawLine(pen, pLeftUp.X, pLeftUp.Y + radius, pLeftDown.X, pLeftDown.Y - radius);
            g.DrawLine(pen, pLeftUp.X + radius, pLeftUp.Y, pRightUp.X - radius, pRightUp.Y);
            g.DrawLine(pen, pRightDown.X, pRightDown.Y - radius, pRightUp.X, pRightUp.Y + radius);
            g.DrawLine(pen, pRightDown.X - radius, pRightDown.Y, pLeftDown.X + radius, pLeftDown.Y);

            if (radius == 0)
                return;

            //画四个圆角
            var rect1 = new Rectangle(pLeftUp, size);
            g.DrawArc(pen, rect1, 180, 90);
            var rect2 = new Rectangle(new Point(pLeftDown.X, pLeftDown.Y - size.Width), size);
            g.DrawArc(pen, rect2, 90, 90);
            var rect3 = new Rectangle(new Point(pRightUp.X - size.Width, pRightUp.Y), size);
            g.DrawArc(pen, rect3, 270, 90);
            var rect4 = new Rectangle(new Point(pRightDown.X - size.Width, pRightDown.Y - size.Width), size);
            g.DrawArc(pen, rect4, 0, 90);
        }
        
        /// <summary>
        /// 设置圆形
        /// </summary>
        private void SetRound()
        {
            IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, BorderRadius, BorderRadius);
            Region = Region.FromHrgn(ptr);
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


        /// <summary>
        /// 防止控件闪烁
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

    }
}
