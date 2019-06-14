using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace WinformSample
{
    public class RoundControl : Component
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

        private Control _ctrl;
        private int _cornerRadius = 5;

        public Control TargetControl
        {
            get { return _ctrl; }
            set
            {
                _ctrl = value;
                _ctrl.SizeChanged += (s, e) =>
                {
                    _ctrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _ctrl.Width, _ctrl.Height, _cornerRadius, _cornerRadius));
                };
            }
        }

        /// <summary>
        /// 需要在窗体的构造函数中赋值才能实现控件的圆角效果
        /// </summary>
        public int CornerRadius
        {
            get { return _cornerRadius; }

            set
            {
                _cornerRadius = value;
                if (_ctrl != null)
                {
                    _ctrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _ctrl.Width, _ctrl.Height, _cornerRadius, _cornerRadius));
                }
            }
        }

        public void SetRound()
        {
            if (_ctrl != null)
            {
                _ctrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _ctrl.Width, _ctrl.Height, _cornerRadius, _cornerRadius));
            }
        }
    }
}
