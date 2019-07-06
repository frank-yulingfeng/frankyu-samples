using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public partial class Form5 : Form
    {
        private readonly Color _Dark_TAN = Color.FromArgb(176, 125, 68);
        private const int _STRING_PADDING = 10;
        private BufferedGraphics _graphicsBuffer;

        public Form5()
        {
            InitializeComponent();
            InitFormMove();
            this.SetStyle(ControlStyles.ResizeRedraw 
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);

            UpdateGraphicsBuffer();
        }
              

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _graphicsBuffer.Graphics.Clear(this.BackColor);

            _graphicsBuffer.Graphics.DrawRectangle(Pens.Gray, new Rectangle
            {
                Location = new Point(0, 0),
                Size = new Size(Width - 1, Height - 1)
            });
            //_graphicsBuffer.Graphics.DrawLine(Pens.LightSteelBlue, new Point(0, 0), new Point(Width, 0));
            //_graphicsBuffer.Graphics.DrawLine(Pens.LightSteelBlue, new Point(0, 0), new Point(0, 31));
            _graphicsBuffer.Render(e.Graphics);            
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            UpdateGraphicsBuffer();
           
        }

        private void UpdateGraphicsBuffer()
        {
            var bufferContext = BufferedGraphicsManager.Current;
            _graphicsBuffer = bufferContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }

        #region 拖拽

        private const int
           HTLEFT = 10,
           HTRIGHT = 11,
           HTTOP = 12,
           HTTOPLEFT = 13,
           HTTOPRIGHT = 14,
           HTBOTTOM = 15,
           HTBOTTOMLEFT = 16,
           HTBOTTOMRIGHT = 17;

        const int _ = 10; // you can rename this variable if you like

        Rectangle TopRect { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
        Rectangle LeftRect { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
        Rectangle BottomRect { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
        Rectangle RightRect { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }

        Rectangle TopLeftRect { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TopRightRect { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
        Rectangle BottomLeftRect { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
        Rectangle BottomRightRect { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            switch (message.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
            }          
                        
            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeftRect.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRightRect.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeftRect.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRightRect.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (TopRect.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (LeftRect.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (RightRect.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (BottomRect.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
        #endregion

        #region 窗口移动代码

        private Point _point;

        private void InitFormMove()
        {
            this.panel1.MouseDown += mouseDown;
            this.panel1.MouseMove += mouseMove;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            _point = new Point(e.X, e.Y);
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Arrow)
                this.Cursor = Cursors.Arrow;
            if (e.Button == MouseButtons.Left)
            {
                Rectangle ScreenArea = Screen.GetWorkingArea(this);
                this.Location = new Point(this.Location.X + e.X - _point.X, this.Location.Y + e.Y - _point.Y);
            }
        }
        #endregion   

        #region 阴影

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private bool m_aeroEnabled;
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        #endregion
    }
}
