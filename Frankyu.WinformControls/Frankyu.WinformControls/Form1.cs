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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.roundControl1.SetRound();
            this.selectionLabel1.AutoSizeHeight();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(hintTextBox1.Text);
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            var contextMenu = new ContextMenu();

            contextMenu.MenuItems.Add(new MenuItem("COPY"));
            contextMenu.MenuItems.Add(new MenuItem("CUT"));
            contextMenu.Show(flatButton1, new Point(0, flatButton1.Height + 3));
        }
    }
}
