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
    public partial class Form1 : Form
    {
        TabButtonCollection _tabManager;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        private static extern Int32 SendMessage(IntPtr hWnd, int msg,
                    int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetHintText(Control control, string text)
        {
            SendMessage(control.Handle, 0x1501, 0, text);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.roundControl1.SetRound();

            _tabManager = new TabButtonCollection(new List<TabButton>
            {
                 tabButton1,
                 tabButton2,
                 tabButton3
            });
            _tabManager.AutoLayout(tabButton1.Location, 3);
            SetHintText(textBox2, "输入你的名字");
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(hintTextBox1.Text);
            _tabManager.AutoVericalLayoutVerical(tabButton1.Location, 3);
            _tabManager.SetProperty(nameof(TabButton.LineLocation), SelectedLineLocation.Right);
            _tabManager.SetProperty(nameof(TabButton.TextAlignment), StringAlignment.Near);

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
    }
}
