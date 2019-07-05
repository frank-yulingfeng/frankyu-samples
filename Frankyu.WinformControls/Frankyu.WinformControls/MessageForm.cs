using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class MessageForm : Form
    {
        string _message = string.Empty;
        string _title = string.Empty;        

        public MessageForm(string message, string title)
        {
            _message = message;
            _title = title;

            InitializeComponent();
            this.BackColor = Color.White;
            this.pnlTitle.BackColor = BackColor;       

            this.Text = title;
            this.lbTitle.Text = title;
            this.lbTitle.Font = GetFont(12f, FontStyle.Regular);
            this.lbTitle.BackColor = pnlTitle.BackColor;
            this.lbTitle.ForeColor = Color.DimGray;

            this.lbMessage.BackColor = BackColor;
            this.lbMessage.Font = GetFont(13f, FontStyle.Regular);
            this.lbMessage.Text = message;

            AutoSizeMessageHeight();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.pnlTitle.MouseDown += mouseDown;
            this.lbTitle.MouseDown += mouseDown;
            this.pnlTitle.MouseMove += mouseMove;
            this.lbTitle.MouseMove += mouseMove;

            btnOK.Text = "确认";
            btnOK.BackColor = Color.FromArgb(42, 131, 242);
            btnOK.ForeColor = Color.White;         

            InitCloseButton();
            this.Paint += MessageForm_Paint;
        }

        private void MessageForm_Paint(object sender, PaintEventArgs e)
        {          
        }

        public void AutoSizeMessageHeight()
        {
            var originHeight = lbMessage.Height;
            var g = this.CreateGraphics();
            var strFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.None
            };

            var size = g.MeasureString(_message, GetFont(13f, FontStyle.Regular),
                lbMessage.Width - lbMessage.Padding.Left - lbMessage.Padding.Right, strFormat);            

            var heightOffset = 20;
            if (size.Height + heightOffset <= 100)
                lbMessage.Height = 100;
            else if (size.Height + heightOffset >= 200)
                lbMessage.Height = 200;
            else
                lbMessage.Height = (int)size.Height + heightOffset + lbMessage.Padding.Top + lbMessage.Padding.Bottom;

            this.Height = Height + (lbMessage.Height - originHeight);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Font GetFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font("微软雅黑", size, style, GraphicsUnit.Pixel);
        }

        #region 窗口移动代码

        private Point _point;

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


        public static void Show(string title, string message)
        {
            MessageForm frm = new MessageForm(message, title);
            frm.ShowDialog();
        }      

        #region 阴影1
        //private const int CS_DropShadow = 0x00020000;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle = CS_DropShadow;

        //        return cp;
        //    }
        //}
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
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 0,
                            leftWidth = 1,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion

        private void InitCloseButton()
        {
            lblClose.MouseDown += LblClose_MouseDown;
            lblClose.MouseUp += LblClose_MouseUp;
            lblClose.MouseEnter += LblClose_MouseEnter;
            lblClose.MouseLeave += LblClose_MouseLeave;
        }

        private void LblClose_MouseDown(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.IndianRed;
            lblClose.ForeColor = BackColor;
        }

        private void LblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Red;
            lblClose.ForeColor = BackColor;
        }

        private void LblClose_MouseUp(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.Red;
            lblClose.ForeColor = BackColor;
        }

        private void LblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Transparent;
            lblClose.ForeColor = Color.DimGray;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
