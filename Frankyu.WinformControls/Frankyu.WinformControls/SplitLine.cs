using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class SplitLine : UserControl
    {
        public bool IsVertical { get; set; }

        private float _lineSize = 1;

        public float LineSize
        {
            get
            {
                return _lineSize;
            }
            set
            {
                if (value < 0)
                {
                    _lineSize = 1;
                    return;
                }

                if (value > 5)
                {
                    _lineSize = 5;
                    return;
                }

                _lineSize = value;
            }
        }

        public Color LineColor { get; set; }

        public SplitLine()
        {
            InitializeComponent();
            LineSize = 1;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (LineSize < 0)
                LineSize = 1f;

            Pen pen = new Pen(LineColor, LineSize);
            if (IsVertical)
            {
                e.Graphics.DrawLine(pen, new Point(1, 0), new Point(1, Height));
            }
            else
            {
                e.Graphics.DrawLine(pen, new Point(0, 1), new Point(Width, 1));
            }
        }

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
