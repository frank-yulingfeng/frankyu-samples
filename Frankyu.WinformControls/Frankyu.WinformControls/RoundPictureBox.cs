using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public class RoundPictureBox : PictureBox
    {
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

        private int _radius = 0;
        /// <summary>
        /// 圆角半径
        /// </summary>
        public int Radius
        {
            get { return _radius; }
            set
            {

                _radius = value;
                SetRound();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetRound();
        }

        private void SetRound()
        {
            IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, _radius, _radius);
            Region = Region.FromHrgn(ptr);
        }
    }
}
