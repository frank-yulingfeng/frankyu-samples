namespace Frankyu.WinformControls
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flatScrollBar1 = new Frankyu.WinformControls.FlatScrollBar();
            this.btnMin = new WinformSample.FlatButton();
            this.btnMax = new WinformSample.FlatButton();
            this.btnClose = new WinformSample.FlatButton();
            this.sysHintTextBox1 = new Frankyu.WinformControls.SysHintTextBox();
            this.tabButton3 = new Frankyu.WinformControls.TabButton();
            this.tabButton2 = new Frankyu.WinformControls.TabButton();
            this.tabButton1 = new Frankyu.WinformControls.TabButton();
            this.roundButton2 = new WindowsFormsApplication1.RoundButton();
            this.flatButton1 = new WinformSample.FlatButton();
            this.hintTextBox2 = new WindowsFormsApplication1.HintTextBox();
            this.roundButton1 = new WindowsFormsApplication1.RoundButton();
            this.hintTextBox1 = new WindowsFormsApplication1.HintTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(366, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 21);
            this.textBox2.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btnMin);
            this.panel1.Controls.Add(this.btnMax);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 30);
            this.panel1.TabIndex = 21;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(12, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 14);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "测试";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(619, 257);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 180);
            this.vScrollBar1.TabIndex = 22;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(410, 257);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(191, 180);
            this.textBox1.TabIndex = 24;
            // 
            // flatScrollBar1
            // 
            this.flatScrollBar1.BackColor = System.Drawing.Color.Transparent;
            this.flatScrollBar1.Location = new System.Drawing.Point(602, 257);
            this.flatScrollBar1.Name = "flatScrollBar1";
            this.flatScrollBar1.Size = new System.Drawing.Size(15, 180);
            this.flatScrollBar1.TabIndex = 100;
            // 
            // btnMin
            // 
            this.btnMin.BorderColor = System.Drawing.Color.Empty;
            this.btnMin.BorderWidth = 0F;
            this.btnMin.CornerRadius = 0;
            this.btnMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Image = global::Frankyu.WinformControls.Properties.Resources.最小化;
            this.btnMin.Location = new System.Drawing.Point(567, 0);
            this.btnMin.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMin.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(34, 30);
            this.btnMin.TabIndex = 2;
            this.btnMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMax
            // 
            this.btnMax.BorderColor = System.Drawing.Color.Empty;
            this.btnMax.BorderWidth = 0F;
            this.btnMax.CornerRadius = 0;
            this.btnMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMax.ForeColor = System.Drawing.Color.White;
            this.btnMax.Image = global::Frankyu.WinformControls.Properties.Resources.最大化;
            this.btnMax.Location = new System.Drawing.Point(601, 0);
            this.btnMax.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMax.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(34, 30);
            this.btnMax.TabIndex = 1;
            this.btnMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.Empty;
            this.btnClose.BorderWidth = 0F;
            this.btnClose.CornerRadius = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::Frankyu.WinformControls.Properties.Resources.关闭;
            this.btnClose.Location = new System.Drawing.Point(635, 0);
            this.btnClose.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnClose.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // sysHintTextBox1
            // 
            this.sysHintTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.sysHintTextBox1.Hint = "Enter your name";
            this.sysHintTextBox1.Location = new System.Drawing.Point(366, 76);
            this.sysHintTextBox1.Name = "sysHintTextBox1";
            this.sysHintTextBox1.Size = new System.Drawing.Size(199, 23);
            this.sysHintTextBox1.TabIndex = 18;
            // 
            // tabButton3
            // 
            this.tabButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tabButton3.HorizonPadding = 10;
            this.tabButton3.IsSelected = false;
            this.tabButton3.LineLocation = Frankyu.WinformControls.SelectedLineLocation.Bottom;
            this.tabButton3.LineWidth = 6F;
            this.tabButton3.Location = new System.Drawing.Point(37, 342);
            this.tabButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabButton3.Name = "tabButton3";
            this.tabButton3.SelectedForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabButton3.SelectedLineColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabButton3.Size = new System.Drawing.Size(112, 35);
            this.tabButton3.TabIndex = 14;
            this.tabButton3.TabText = "未读邮件";
            this.tabButton3.TextAlignment = System.Drawing.StringAlignment.Center;
            this.tabButton3.UnselectedLineColor = System.Drawing.Color.LightGray;
            this.tabButton3.UnselectedLineWidth = 3F;
            this.tabButton3.VericalPadding = 10;
            // 
            // tabButton2
            // 
            this.tabButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tabButton2.HorizonPadding = 10;
            this.tabButton2.IsSelected = false;
            this.tabButton2.LineLocation = Frankyu.WinformControls.SelectedLineLocation.Bottom;
            this.tabButton2.LineWidth = 6F;
            this.tabButton2.Location = new System.Drawing.Point(37, 299);
            this.tabButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabButton2.Name = "tabButton2";
            this.tabButton2.SelectedForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabButton2.SelectedLineColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabButton2.Size = new System.Drawing.Size(112, 35);
            this.tabButton2.TabIndex = 13;
            this.tabButton2.TabText = "已加密";
            this.tabButton2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.tabButton2.UnselectedLineColor = System.Drawing.Color.LightGray;
            this.tabButton2.UnselectedLineWidth = 3F;
            this.tabButton2.VericalPadding = 10;
            // 
            // tabButton1
            // 
            this.tabButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tabButton1.HorizonPadding = 10;
            this.tabButton1.IsSelected = true;
            this.tabButton1.LineLocation = Frankyu.WinformControls.SelectedLineLocation.Bottom;
            this.tabButton1.LineWidth = 6F;
            this.tabButton1.Location = new System.Drawing.Point(37, 257);
            this.tabButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabButton1.Name = "tabButton1";
            this.tabButton1.SelectedForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabButton1.SelectedLineColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabButton1.Size = new System.Drawing.Size(112, 35);
            this.tabButton1.TabIndex = 12;
            this.tabButton1.TabText = "全部";
            this.tabButton1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.tabButton1.UnselectedLineColor = System.Drawing.Color.LightGray;
            this.tabButton1.UnselectedLineWidth = 3F;
            this.tabButton1.VericalPadding = 10;
            // 
            // roundButton2
            // 
            this.roundButton2.BorderColors = System.Drawing.Color.LightGray;
            this.roundButton2.BorderWidth = 1F;
            this.roundButton2.FlatAppearance.BorderSize = 0;
            this.roundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton2.Location = new System.Drawing.Point(37, 112);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Radius = 3;
            this.roundButton2.Size = new System.Drawing.Size(153, 51);
            this.roundButton2.TabIndex = 5;
            this.roundButton2.Text = "OK";
            this.roundButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.roundButton2.UseVisualStyleBackColor = true;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.SystemColors.Control;
            this.flatButton1.BorderColor = System.Drawing.Color.Silver;
            this.flatButton1.BorderWidth = 1F;
            this.flatButton1.CornerRadius = 3;
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton1.Location = new System.Drawing.Point(365, 110);
            this.flatButton1.MouseDownBackColor = System.Drawing.Color.Silver;
            this.flatButton1.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.flatButton1.Size = new System.Drawing.Size(203, 38);
            this.flatButton1.TabIndex = 4;
            this.flatButton1.Text = "新建笔记";
            this.flatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click);
            // 
            // hintTextBox2
            // 
            this.hintTextBox2.BorderRadius = 0;
            this.hintTextBox2.BorderWidth = 0.01F;
            this.hintTextBox2.Font = new System.Drawing.Font("SimHei", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hintTextBox2.HightLight = false;
            this.hintTextBox2.HintText = "hint";
            this.hintTextBox2.Location = new System.Drawing.Point(365, 186);
            this.hintTextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hintTextBox2.Name = "hintTextBox2";
            this.hintTextBox2.PasswordChar = '\0';
            this.hintTextBox2.Size = new System.Drawing.Size(199, 37);
            this.hintTextBox2.TabIndex = 2;
            // 
            // roundButton1
            // 
            this.roundButton1.BorderColors = System.Drawing.Color.LightGray;
            this.roundButton1.BorderWidth = 1F;
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Location = new System.Drawing.Point(37, 68);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Radius = 3;
            this.roundButton1.Size = new System.Drawing.Size(159, 38);
            this.roundButton1.TabIndex = 1;
            this.roundButton1.Text = "OK";
            this.roundButton1.UseVisualStyleBackColor = true;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // hintTextBox1
            // 
            this.hintTextBox1.BorderRadius = 3;
            this.hintTextBox1.BorderWidth = 0.01F;
            this.hintTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintTextBox1.HightLight = true;
            this.hintTextBox1.HintText = "Enter your name";
            this.hintTextBox1.Location = new System.Drawing.Point(365, 151);
            this.hintTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hintTextBox1.Name = "hintTextBox1";
            this.hintTextBox1.PasswordChar = '\0';
            this.hintTextBox1.Size = new System.Drawing.Size(200, 28);
            this.hintTextBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 509);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flatScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sysHintTextBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tabButton3);
            this.Controls.Add(this.tabButton2);
            this.Controls.Add(this.tabButton1);
            this.Controls.Add(this.roundButton2);
            this.Controls.Add(this.flatButton1);
            this.Controls.Add(this.hintTextBox2);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.hintTextBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(200, 80);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "TEST";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsApplication1.HintTextBox hintTextBox1;
        private WindowsFormsApplication1.RoundButton roundButton1;
        private WindowsFormsApplication1.HintTextBox hintTextBox2;
        private WinformSample.FlatButton flatButton1;
        private WindowsFormsApplication1.RoundButton roundButton2;
        private TabButton tabButton1;
        private TabButton tabButton2;
        private TabButton tabButton3;
        private System.Windows.Forms.TextBox textBox2;
        private SysHintTextBox sysHintTextBox1;
        private System.Windows.Forms.Panel panel1;
        private WinformSample.FlatButton btnClose;
        private WinformSample.FlatButton btnMax;
        private WinformSample.FlatButton btnMin;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private FlatScrollBar flatScrollBar1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

