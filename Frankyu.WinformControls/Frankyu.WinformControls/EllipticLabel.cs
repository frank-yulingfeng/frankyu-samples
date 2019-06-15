using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public class EllipticLabel : Label
    {
        public EllipticLabel()
            : base()
        {
            base.AutoSize = false;
            this.Width = 100;
            this.Height = 100;
            TextAlign = ContentAlignment.MiddleCenter;
            ImageAlign = ContentAlignment.MiddleCenter;
            BackColor = Color.Transparent;
        }

        public Color EllipticColor { get; set; }

        public Size ImageSize { get; set; }

        public Size ImageOffset { get; set; }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // This ensures that the corners of the label will have the same color as the
            // container control or form. They would be black otherwise.
            //e.Graphics.Clear(Parent.BackColor);

            if (EllipticColor.IsEmpty)
                return;

            // This does the trick
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = ClientRectangle;
            rect.Width--;
            rect.Height--;
            using (var brush = new SolidBrush(EllipticColor))
            {
                e.Graphics.FillEllipse(brush, rect);
            }

            StringFormat strFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };

            if (!string.IsNullOrEmpty(Text))
            {
                e.Graphics.DrawString(this.Text, Font, new SolidBrush(this.ForeColor), rect, strFormat);
            }

            if (Image != null)
            {
                var x = (rect.Width - ImageSize.Width) / 2;
                var y = (rect.Height - ImageSize.Height) / 2;

                Rectangle imgRect = new Rectangle(x + ImageOffset.Width, y + ImageOffset.Height, ImageSize.Width, ImageSize.Height);
                e.Graphics.DrawImage(Image, imgRect);
            }
        }
    }
}
