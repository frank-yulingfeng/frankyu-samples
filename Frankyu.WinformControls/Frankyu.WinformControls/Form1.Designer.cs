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
            this.hintTextBox2 = new WindowsFormsApplication1.HintTextBox();
            this.roundButton1 = new WindowsFormsApplication1.RoundButton();
            this.hintTextBox1 = new WindowsFormsApplication1.HintTextBox();
            this.SuspendLayout();
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
            this.roundButton1.Location = new System.Drawing.Point(150, 92);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Radius = 3;
            this.roundButton1.Size = new System.Drawing.Size(100, 28);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 258);
            this.Controls.Add(this.hintTextBox2);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.hintTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApplication1.HintTextBox hintTextBox1;
        private WindowsFormsApplication1.RoundButton roundButton1;
        private WindowsFormsApplication1.HintTextBox hintTextBox2;
    }
}

