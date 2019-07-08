using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public partial class Form6 : Form
    {
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int WM_NCHITTEST = 0x84;
        const int HT_CAPTION = 0x2;
        const int WM_NCCALCSIZE = 0x83;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left, top, right, bottom;
            
            public RECT(Rectangle rc)
            {
                this.left = rc.Left;
                this.top = rc.Top;
                this.right = rc.Right;
                this.bottom = rc.Bottom;
            }

            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(left, top, right, bottom);
            }

        }

        [StructLayout(LayoutKind.Sequential)]
        private struct NCCALCSIZE_PARAMS
        {
            public RECT rgrc0, rgrc1, rgrc2;
            public WINDOWPOS lppos;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPOS
        {
            public IntPtr hWnd, hWndInsertAfter;
            public int x, y, cx, cy, flags;
        }
               
        public Form6()
        {
            InitializeComponent();
            panel1.MouseDown += panel1_MouseDown;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCCALCSIZE:
                    if (m.WParam.Equals(IntPtr.Zero))
                    {

                        RECT rc = (RECT)m.GetLParam(typeof(RECT));
                        Rectangle r = rc.ToRectangle();
                        r.Inflate(8, 8);
                        Marshal.StructureToPtr(new RECT(r), m.LParam, true);
                    }
                    else
                    {
                        NCCALCSIZE_PARAMS csp = (NCCALCSIZE_PARAMS)m.GetLParam(typeof(NCCALCSIZE_PARAMS));
                        Rectangle r = csp.rgrc0.ToRectangle();
                        r.Inflate(8, 8);
                        csp.rgrc0 = new RECT(r);
                        Marshal.StructureToPtr(csp, m.LParam, true);
                    }
                    m.Result = IntPtr.Zero;
                    break;
            }

            base.WndProc(ref m);

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message msg = Message.Create(Handle, WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, IntPtr.Zero);
            WndProc(ref msg);
        }
    }
}
