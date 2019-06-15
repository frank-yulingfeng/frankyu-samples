using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public class CircularButton : Label
    {
        public CircularButton()
            : base()
        {
            base.AutoSize = false;
            this.Width = 100;
            this.Height = 100;
            TextAlign = ContentAlignment.MiddleCenter;
            ImageAlign = ContentAlignment.MiddleCenter;
        }

        public override bool AutoSize
        {
            get
            {
                //return base.AutoSize;
                return false;
            }
            set
            {
                base.AutoSize = false;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetRegion();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SetRegion();
        }

        private void SetRegion()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
            this.Region = new Region(path);
        }

        #region 点击事件

        public Color MouseOverBackColor { get; set; }

        public Color MouseDownBackColor { get; set; }

        private Color _backColor;

        protected override void OnMouseEnter(EventArgs e)
        {
            _backColor = BackColor;

            base.OnMouseEnter(e);
            if (MouseOverBackColor.IsEmpty)
                return;

            BackColor = MouseOverBackColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = _backColor;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            if (MouseDownBackColor.IsEmpty)
                return;

            BackColor = MouseDownBackColor;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            BackColor = MouseOverBackColor;
        }

        #endregion
    }
}
