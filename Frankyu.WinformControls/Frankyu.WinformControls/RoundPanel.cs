using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public class RoundPanel : Panel
    {

        /// <summary>
        /// 圆角半径
        /// </summary>
        public int CornerRadius { get; set; }

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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (BorderStyle != BorderStyle.None)
                return;

            DrawShadom(e.Graphics, ClientRectangle);
        }

        private void DrawShadom(Graphics g, Rectangle rect)
        {
            //一共画5圈
            var pen1 = new Pen(Color.FromArgb(236, 236, 236), 0.5f);
            g.DrawRectangle(pen1, rect);

            //第二圈
            var pen2 = new Pen(Color.FromArgb(230, 230, 230), 0.5f);
            var rect2 = new Rectangle
            {
                //Location = rect.Location - new Size(1, 1),
                Size = rect.Size - new Size(1, 1),
            };
            
            g.DrawRectangle(pen2, rect2);            

            var pen3 = new Pen(Color.FromArgb(223, 223, 223), 0.5f);
            var rect3 = new Rectangle
            {
                //Location = rect2.Location - new Size(1, 1),
                Size = rect2.Size - new Size(1, 1),
            };
            g.DrawRectangle(pen3, rect3);

            var pen4 = new Pen(Color.FromArgb(213, 213, 213), 0.5f);
            var rect4 = new Rectangle
            {
                //Location = rect3.Location - new Size(1, 1),
                Size = rect3.Size - new Size(1, 1),
            };
            g.DrawRectangle(pen4, rect4);

            var pen5 = new Pen(Color.FromArgb(205, 205, 205), 0.5f);
            var rect5 = new Rectangle
            {
                //Location = rect4.Location - new Size(1, 1),
                Size = rect4.Size - new Size(1, 1),
            };
            g.DrawRectangle(Pens.Brown, rect5);
        }
    }
}
