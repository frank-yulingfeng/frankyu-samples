using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformSample
{
    public class FlatButton : Label
    {
        private float _borderWidth = 0;
        public float BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                if (value < 0)
                {
                    _borderWidth = 0;

                }
                else
                {
                    _borderWidth = value;
                }
                SetRound();
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
            }
        }

        public FlatButton()
            : base()
        {
            AutoSize = false;
            BorderStyle = BorderStyle.None;
            TextAlign = ContentAlignment.MiddleCenter;
            FlatStyle = FlatStyle.Flat;

            BackColor = Color.Transparent;
            _cornerRadius = 0;
        }

        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                if (value == true)
                    return;

                base.AutoSize = value;
            }
        }

        public Color MouseOverBackColor { get; set; }

        public Color MouseDownBackColor { get; set; }

        private Color _backColor;

        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                _backColor = value;
            }
        }

        private string _text;

        public new string Text
        {
            get { return base.Text; }
            set
            {
                _text = value;
                base.Text = _text;
            }
        }

        public new bool Enabled
        {
            get
            {
                return base.Enabled;

            }
            set
            {
                base.Enabled = value;

                if (!value)
                {
                    base.BackColor = MouseDownBackColor;                        
                }
                else
                {
                    base.BackColor = _backColor;
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (MouseOverBackColor.IsEmpty)
                return;

            base.BackColor = MouseOverBackColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            base.BackColor = _backColor;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left)
                return;

            if (MouseDownBackColor.IsEmpty)
                return;

            base.BackColor = MouseDownBackColor;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button != MouseButtons.Left)
                return;

            base.BackColor = MouseOverBackColor;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetRound();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (Enabled)
            {
                base.BackColor = BackColor;
            }
            else
            {
                base.BackColor = ControlPaint.Light(BackColor);
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

        private int _cornerRadius = 0;

        public int CornerRadius
        {
            get { return _cornerRadius; }

            set
            {
                _cornerRadius = value;
                SetRound();
            }
        }

        public override BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }
            set
            {
                if (value != BorderStyle.None)
                    return;

                base.BorderStyle = value;
            }
        }

        public new FlatStyle FlatStyle
        {
            get
            {
                return base.FlatStyle;
            }
            set
            {
                if (value != FlatStyle.Flat)
                    return;

                base.FlatStyle = value;
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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (!Enabled)
            {
                base.Text = string.Empty;

                if (string.IsNullOrEmpty(_text))
                    return;

                StringFormat format = new StringFormat
                {
                    Alignment = GetHorizontalAlignment(),
                    LineAlignment = GetVericalAlignment(),
                    Trimming = AutoEllipsis ? StringTrimming.EllipsisCharacter : StringTrimming.None,
                    FormatFlags = StringFormatFlags.MeasureTrailingSpaces
                };

                pevent.Graphics.DrawString(_text, Font, new SolidBrush(ForeColor), new Rectangle
                {
                    Location = ClientRectangle.Location,
                    Size = ClientRectangle.Size - new Size(2, 0),
                }, format);
            }
            else
            {
                base.Text = _text;
            }

            if (BorderColor.IsEmpty)
                return;

            if (BorderWidth <= 0)
                return;

            Pen pen = new Pen(BorderColor, BorderWidth);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            pevent.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;//消除锯齿
            DrawRoundRect(pevent.Graphics, pen, new Point(0, 0), Width - 1, Height - 1, CornerRadius);
        }

        private void SetRound()
        {
            var corerRadius = CornerRadius; //+ (BorderWidth > 0 ? 1 : 0);
            IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, corerRadius, corerRadius);
            Region = Region.FromHrgn(ptr);
        }
        
        private StringAlignment GetVericalAlignment()
        {
            switch (TextAlign)
            {
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomRight:
                case ContentAlignment.BottomCenter:
                    return StringAlignment.Near;

                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    return StringAlignment.Center;

                case ContentAlignment.TopCenter:
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopRight:
                    return StringAlignment.Far;
            }

            return StringAlignment.Center;
        }

        private StringAlignment GetHorizontalAlignment()
        {
            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    return StringAlignment.Near;

                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    return StringAlignment.Far;

                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    return StringAlignment.Center;
            }

            return StringAlignment.Center;
        }
    }
}
