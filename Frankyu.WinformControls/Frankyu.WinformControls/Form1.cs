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
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(hintTextBox1.Text);
        }
    }
}
