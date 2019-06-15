using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public partial class Form2 : Form
    {
        private string filePath = string.Empty;

        private List<string> imageFiles = new List<string>();

        public Form2()
        {
            InitializeComponent();
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                filePath = dialog.SelectedPath;
                btnSelectPath.Text = Path.GetDirectoryName(filePath);

                DirectoryInfo dirInfo = new DirectoryInfo(filePath);
                imageFiles.Clear();
                foreach (var file in dirInfo.GetFiles())
                {
                    imageFiles.Add(file.FullName);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (imageFiles.Count == 0)
                return;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Start();

            this.Hide();
        }

        int index = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            if (index >= imageFiles.Count)
            {
                ((Timer)sender).Stop();
                return;
            }
            ((Timer)sender).Interval = 10000;

            int x = 10;
            int y = 10;

            //偶数
            if (index / 2 == 0)
            {
                x += index * 100;
            }
            else
            {
                //奇数
                y += index * 100;
            }

            Form3 frm = new Form3(imageFiles[index], x, y);            
            frm.Show();

            index++;
        }
    }
}
