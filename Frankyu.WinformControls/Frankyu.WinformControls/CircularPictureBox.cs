using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public class CircularPictureBox : PictureBox
    {
        public CircularPictureBox()
            : base()
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
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
    }
}
