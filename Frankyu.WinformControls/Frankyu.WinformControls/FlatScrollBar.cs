using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public partial class FlatScrollBar : UserControl
    {
        public FlatScrollBar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            this.ScrollContainer.MouseClick += ScrollContainer_MouseClick;
            this.ScrollAt.MouseDown += ScrollAt_MouseDown;
            this.ScrollAt.MouseMove += ScrollAt_MouseMove;
            this.ScrollAt.MouseUp += ScrollAt_MouseUp;
            this.MouseWheel += FlatScrollBar_MouseWheel;
        }

        void ScrollContainer_MouseClick(object sender, MouseEventArgs e)
        {
            this.Focus(); 
        }

        int interval = 10;
        void FlatScrollBar_MouseWheel(object sender, MouseEventArgs e)
        {
            var originY = ScrollAt.Location.Y;
            var max_Y = this.Height - ScrollAt.Height - 3;
            //当e.Delta > 0时鼠标滚轮是向上滚动，e.Delta < 0时鼠标滚轮向下滚动
            var offset = e.Delta > 0 ? interval * -1 : interval;
            var y = offset + ScrollAt.Location.Y;
            if (y <= 1)
                y = 1;
            else if (y >= max_Y)
                y = max_Y;

            ScrollAt.Location = new Point(_Scroll_X, y);
        }

        const int _Scroll_X = 1;
        bool _isMouseDown = false;
        Point _mousePosition = new Point(0, 0);
        void ScrollAt_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        void ScrollAt_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                if (Math.Abs(e.Location.X - _mousePosition.Y) > 50)
                    return;

                var max_Y = this.ScrollContainer.Height - ScrollAt.Height - 3;
                var offset = e.Location.Y - _mousePosition.Y;
                var y = offset + ScrollAt.Location.Y;
                if (y <= 1)
                    y = 1;
                else if (y >= max_Y)
                    y = max_Y;

                ScrollAt.Location = new Point(_Scroll_X, y);
            }
        }

        void ScrollAt_MouseDown(object sender, MouseEventArgs e)
        {
            this.Focus(); 
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _isMouseDown = true;
                _mousePosition = e.Location;
            }
        }       
    }
}
