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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();

            myTextBox1.Text = "发的数据分类的是飞机迪斯科浪费是费德勒开始发动机是离开法拉伐就撒旦克里夫奥斯卡JFK拉萨飞机卡洛斯附近啊考虑时间GIF的结果佛的结果覅殴打结果i佛的国家的覅哦官方的结果偶分低价格都fig觉得覅欧冠将颠覆国家了甲方领导开始机房上课了解开了解放拉萨大技法卢卡斯飞机阿瑟东i发几顿饭iOS就粉底哦按时间地方偶爱伺机待发iOS地方教师的副教授的房间哦建瓯阿斯蒂芬偶就覅都是及";
                        
            SizeChanged += Form7_SizeChanged;
            Form7_SizeChanged(null, null);
        }

        private void Form7_SizeChanged(object sender, EventArgs e)
        {
            ////var g = CreateGraphics();
            ////var sizeF = g.MeasureString(richTextBox1.Text, richTextBox1.Font, richTextBox1.Width - 90, new StringFormat
            ////{
            ////    Alignment = StringAlignment.Near,
            ////    LineAlignment = StringAlignment.Near,
            ////    FormatFlags = StringFormatFlags.LineLimit,
            ////    Trimming = StringTrimming.None
            ////});

            int count = this.myTextBox1.GetLineCount();
            if (count <= 6)
            {
                myTextBox1.Height = 16 * count + 12;
            }
            else
            {
                myTextBox1.Height = 17 * count + 10;
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
