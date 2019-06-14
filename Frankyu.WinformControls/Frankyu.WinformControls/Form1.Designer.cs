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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roundButton2 = new WindowsFormsApplication1.RoundButton();
            this.flatButton1 = new WinformSample.FlatButton();
            this.roundPictureBox1 = new Frankyu.WinformControls.RoundPictureBox();
            this.hintTextBox2 = new WindowsFormsApplication1.HintTextBox();
            this.roundButton1 = new WindowsFormsApplication1.RoundButton();
            this.hintTextBox1 = new WindowsFormsApplication1.HintTextBox();
            this.roundControl1 = new WinformSample.RoundControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(370, 267);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // roundButton2
            // 
            this.roundButton2.BorderColors = System.Drawing.Color.LightGray;
            this.roundButton2.BorderWidth = 1F;
            this.roundButton2.FlatAppearance.BorderSize = 0;
            this.roundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton2.Location = new System.Drawing.Point(343, 163);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Radius = 3;
            this.roundButton2.Size = new System.Drawing.Size(153, 51);
            this.roundButton2.TabIndex = 5;
            this.roundButton2.Text = "OK";
            this.roundButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.roundButton2.UseVisualStyleBackColor = true;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.SystemColors.Control;
            this.flatButton1.BorderColor = System.Drawing.Color.Silver;
            this.flatButton1.BorderWidth = 1F;
            this.flatButton1.CornerRadius = 3;
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton1.Location = new System.Drawing.Point(368, 92);
            this.flatButton1.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flatButton1.MouseOverBackColor = System.Drawing.Color.Silver;
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.flatButton1.Size = new System.Drawing.Size(128, 38);
            this.flatButton1.TabIndex = 4;
            this.flatButton1.Text = "新建笔记";
            this.flatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundPictureBox1
            // 
            this.roundPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("roundPictureBox1.Image")));
            this.roundPictureBox1.Location = new System.Drawing.Point(86, 227);
            this.roundPictureBox1.Name = "roundPictureBox1";
            this.roundPictureBox1.Radius = 6;
            this.roundPictureBox1.Size = new System.Drawing.Size(115, 107);
            this.roundPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPictureBox1.TabIndex = 3;
            this.roundPictureBox1.TabStop = false;
            // 
            // hintTextBox2
            // 
            this.hintTextBox2.BorderColors = System.Drawing.Color.LightGray;
            this.hintTextBox2.BorderRadius = 0;
            this.hintTextBox2.BorderWidth = 0.01F;
            this.hintTextBox2.Font = new System.Drawing.Font("SimHei", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hintTextBox2.HightLight = false;
            this.hintTextBox2.HintText = "hint";
            this.hintTextBox2.Location = new System.Drawing.Point(37, 154);
            this.hintTextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hintTextBox2.Name = "hintTextBox2";
            this.hintTextBox2.PasswordChar = '\0';
            this.hintTextBox2.Size = new System.Drawing.Size(213, 37);
            this.hintTextBox2.TabIndex = 2;
            // 
            // roundButton1
            // 
            this.roundButton1.BorderColors = System.Drawing.Color.LightGray;
            this.roundButton1.BorderWidth = 1F;
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Location = new System.Drawing.Point(91, 92);
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
            this.hintTextBox1.BorderColors = System.Drawing.Color.LightGray;
            this.hintTextBox1.BorderRadius = 3;
            this.hintTextBox1.BorderWidth = 0.01F;
            this.hintTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintTextBox1.HightLight = true;
            this.hintTextBox1.HintText = "Enter your name";
            this.hintTextBox1.Location = new System.Drawing.Point(50, 28);
            this.hintTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hintTextBox1.Name = "hintTextBox1";
            this.hintTextBox1.PasswordChar = '\0';
            this.hintTextBox1.Size = new System.Drawing.Size(200, 28);
            this.hintTextBox1.TabIndex = 0;
            // 
            // roundControl1
            // 
            this.roundControl1.CornerRadius = 5;
            this.roundControl1.TargetControl = this.pictureBox1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 448);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.roundButton2);
            this.Controls.Add(this.flatButton1);
            this.Controls.Add(this.roundPictureBox1);
            this.Controls.Add(this.hintTextBox2);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.hintTextBox1);
            this.Name = "Form1";
            this.Text = "TEST";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApplication1.HintTextBox hintTextBox1;
        private WindowsFormsApplication1.RoundButton roundButton1;
        private WindowsFormsApplication1.HintTextBox hintTextBox2;
        private RoundPictureBox roundPictureBox1;
        private WinformSample.FlatButton flatButton1;
        private WindowsFormsApplication1.RoundButton roundButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private WinformSample.RoundControl roundControl1;
    }
}

