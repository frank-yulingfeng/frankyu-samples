using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public partial class Form3 : Form
    {
        int ScreenWidth = SystemInformation.PrimaryMonitorMaximizedWindowSize.Width;//屏幕的宽度
        int ScreenHeight = SystemInformation.PrimaryMonitorMaximizedWindowSize.Height;//屏幕的高度

        private int x = 2, y = 2;

        public Form3(string fileName, int startX = 2, int startY = 2)
        {
            InitializeComponent();
            Location = new Point(startX, startY);
            ShowInTaskbar = false;
            this.Width = 150;
            this.Height = 150;

            var image = Image.FromFile(fileName);
            this.roundPictureBox2.Image = image;

            Timer timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 40;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Location = new Point(Location.X + x, Location.Y + y);
            if (Location.X + Width >= Screen.PrimaryScreen.WorkingArea.Width)
                x = -2;
            else if (Location.X <= 0)
                x = 1;
            if (Location.Y + Height >= Screen.PrimaryScreen.WorkingArea.Height)
                y = -2;
            else if (Location.Y <= 0)
                y = 1;
        }

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
    }
}
