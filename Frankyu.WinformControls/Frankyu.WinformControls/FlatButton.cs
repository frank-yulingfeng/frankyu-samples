using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
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
            Enabled = true;
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

        private bool _enabled = true;
        public new bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                if (_enabled)
                {
                    base.BackColor = _backColor;
                }
                else
                {
                    if (_backColor == Color.Transparent)
                        return;

                    base.BackColor = ControlPaint.LightLight(_backColor);
                }
            }
        }     
        
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (MouseOverBackColor.IsEmpty || !this.Enabled)
            {
                return;
            }

            base.BackColor = MouseOverBackColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.Enabled)
                return;

            base.BackColor = _backColor;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left)
                return;

            if (!this.Enabled)
                return;

            if (MouseDownBackColor.IsEmpty)
            {
                if (_backColor == Color.Transparent)
                    return;

                base.BackColor = ControlPaint.Light(_backColor);
                return;
            }

            base.BackColor = MouseDownBackColor;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button != MouseButtons.Left)
                return;

            if (!this.Enabled)
                return;

            if (MouseOverBackColor.IsEmpty )
            {
                if (_backColor == Color.Transparent)
                    return;

                base.BackColor = _backColor;
                return;                
            }

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
                base.BackColor = _backColor;
            }
            else
            {
                if (!BackColor.IsEmpty && BackColor != Color.Transparent)
                    base.BackColor = ControlPaint.Light(_backColor);
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
        
        public GraphicsPath RoundedRect(Rectangle bounds, int radius)
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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

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
            var rect = new Rectangle
            {
                Location = ClientRectangle.Location,
                Size = ClientRectangle.Size - new Size(1, 1)
            };
            pevent.Graphics.DrawPath(pen, RoundedRect(rect, CornerRadius));
        }

        private void SetRound()
        {
            var corerRadius = CornerRadius + (BorderWidth > 0 ? 1 : 0);
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
