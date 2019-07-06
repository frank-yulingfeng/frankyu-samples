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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            ControlPaint.DrawBorder3D(CreateGraphics(), new Rectangle()
            {
                Location = new Point(10, 10),
                Size = new Size(20, 20)
            }, Border3DStyle.Flat);

            ControlPaint.DrawCheckBox(e.Graphics, new Rectangle()
            {
                Location = new Point(10, 50),
                Size = new Size(20, 20)
            }, ButtonState.Flat);

            ControlPaint.DrawButton(e.Graphics, new Rectangle {
                Location = new Point(10, 100),
                Size = new Size(50, 30)
            }, ButtonState.Normal);

            ControlPaint.DrawCaptionButton(e.Graphics, new Rectangle
            {
                Location = new Point(10, 150),
                Size = new Size(30, 30)
            }, CaptionButton.Close, ButtonState.All);

            ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle
            {
                Location = new Point(10, 200),
                Size = new Size(30, 30)
            }, Color.Gray, Color.LightGray);

            ControlPaint.DrawContainerGrabHandle(e.Graphics, new Rectangle
            {
                Location = new Point(10, 250),
                Size = new Size(30, 30)
            });

            ControlPaint.DrawGrid(e.Graphics, new Rectangle
            {
                Location = new Point(10, 300),
                Size = new Size(30, 30)
            },new Size(1,1),Color.White);

            ControlPaint.DrawSelectionFrame(e.Graphics,false, new Rectangle
            {
                Location = new Point(10, 350),
                Size = new Size(30, 30)
            }, new Rectangle
            {
                Location = new Point(500, 350),
                Size = new Size(50, 30)
            },Color.LightSalmon);

            ControlPaint.Light(Color.Gray);
        }
    }
}
