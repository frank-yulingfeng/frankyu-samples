namespace Frankyu.WinformControls
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hintTextBox1 = new WindowsFormsApplication1.HintTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flatButton1 = new WinformSample.FlatButton();
            this.flatButton2 = new WinformSample.FlatButton();
            this.SuspendLayout();
            // 
            // hintTextBox1
            // 
            this.hintTextBox1.BorderColors = System.Drawing.Color.LightGray;
            this.hintTextBox1.BorderRadius = 3;
            this.hintTextBox1.BorderWidth = 0.01F;
            this.hintTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintTextBox1.HightLight = true;
            this.hintTextBox1.HintText = "Enter your name";
            this.hintTextBox1.Location = new System.Drawing.Point(173, 135);
            this.hintTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hintTextBox1.Name = "hintTextBox1";
            this.hintTextBox1.PasswordChar = '\0';
            this.hintTextBox1.Size = new System.Drawing.Size(200, 28);
            this.hintTextBox1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 30);
            this.panel1.TabIndex = 2;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.SystemColors.Control;
            this.flatButton1.BorderColor = System.Drawing.Color.Empty;
            this.flatButton1.BorderWidth = 0F;
            this.flatButton1.CornerRadius = 3;
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.flatButton1.Image = global::Frankyu.WinformControls.Properties.Resources.reply;
            this.flatButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton1.Location = new System.Drawing.Point(52, 135);
            this.flatButton1.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.flatButton1.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Padding = new System.Windows.Forms.Padding(5, 0, 8, 0);
            this.flatButton1.Size = new System.Drawing.Size(71, 28);
            this.flatButton1.TabIndex = 3;
            this.flatButton1.Text = "回复";
            this.flatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.flatButton2.BorderColor = System.Drawing.Color.Silver;
            this.flatButton2.BorderWidth = 1F;
            this.flatButton2.CornerRadius = 3;
            this.flatButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton2.Location = new System.Drawing.Point(52, 88);
            this.flatButton2.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.flatButton2.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Size = new System.Drawing.Size(100, 23);
            this.flatButton2.TabIndex = 4;
            this.flatButton2.Text = "flatButton2";
            this.flatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(546, 299);
            this.Controls.Add(this.flatButton2);
            this.Controls.Add(this.flatButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hintTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsApplication1.HintTextBox hintTextBox1;
        private System.Windows.Forms.Panel panel1;
        private WinformSample.FlatButton flatButton1;
        private WinformSample.FlatButton flatButton2;
    }
}