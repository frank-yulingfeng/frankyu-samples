using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public partial class Form1 : Form
    {
        TabButtonCollection _tabManager;

        public Form1()
        {
            InitializeComponent();
            InitFormMove();

            _tabManager = new TabButtonCollection(new List<TabButton>
            {
                 tabButton1,
                 tabButton2,
                 tabButton3
            });
            _tabManager.AutoLayout(tabButton1.Location, 0);
            _tabManager.SetProperty("UnselectedLineWidth", 1f);

            DoubleBuffered = true;
            for (int i = 0; i < 100; i++)
            {
                this.textBox1.Text += "这是第" + (i + 1) + "行\r\n";
            }

            this.vScrollBar1.Minimum = 0;
            this.vScrollBar1.Maximum = this.textBox1.DisplayRectangle.Height;
            this.vScrollBar1.LargeChange = vScrollBar1.Maximum / vScrollBar1.Height;
            this.vScrollBar1.SmallChange = 15;
            this.vScrollBar1.Value = Math.Abs(this.textBox1.AutoScrollOffset.Y);
            vScrollBar1.Scroll += vScrollBar1_Scroll;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.AutoScrollOffset = new Point(0, vScrollBar1.Value);
            Application.DoEvents();
            //Debug.WriteLine("vscroll: " + vScrollBar1.Value.ToString() + "  custom: " + customScrollbar1.Value.ToString());
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(hintTextBox1.Text);
            _tabManager.AutoVericalLayoutVerical(tabButton1.Location, 0);
            _tabManager.SetProperty("LineLocation", SelectedLineLocation.Right);
            _tabManager.SetProperty("TextAlignment", StringAlignment.Far);
            _tabManager.SetProperty("HorizonPadding", 15);

            sysHintTextBox1.Hint = "请输入您的年龄";
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            var contextMenu = new ContextMenu();

            contextMenu.MenuItems.Add(new MenuItem("COPY"));
            contextMenu.MenuItems.Add(new MenuItem("CUT"));
            contextMenu.Show(flatButton1, new Point(0, flatButton1.Height + 3));
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.MessageForm frm = new WindowsFormsApplication1.MessageForm("登录成功", "提示");
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        #region 窗口移动代码

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void InitFormMove()
        {
           panel1.MouseDown += mouseDown;            
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 2)
                {
                    btnMax_Click(null, null);
                }
                else
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
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
        #endregion


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
                if (WindowState == FormWindowState.Maximized)
                    return;

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

        private void Form1_Load(object sender, EventArgs e)
        {            
        }
        
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMax.Image = Properties.Resources.最大化;
            }
            else
            {
                btnMax.Image = Properties.Resources.标准大小;
                Screen screen = Screen.FromControl(this);
                int x = screen.WorkingArea.X - screen.Bounds.X;
                int y = screen.WorkingArea.Y - screen.Bounds.Y;
                this.MaximizedBounds = new Rectangle(x, y,
                    screen.WorkingArea.Width, screen.WorkingArea.Height);
                this.MaximumSize = screen.WorkingArea.Size;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void flatButton2_Click(object sender, EventArgs e)
        {
            textBox1.AutoScrollOffset = new Point(textBox1.Location.X, textBox1.Location.Y + textBox1.Height);
        }
    }
}
