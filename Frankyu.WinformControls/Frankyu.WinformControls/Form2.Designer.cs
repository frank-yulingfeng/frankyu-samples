namespace Frankyu.WinformControls
{
    partial class Form2
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
            this.btnStart = new WinformSample.FlatButton();
            this.btnSelectPath = new WinformSample.FlatButton();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnStart.BorderWidth = 1F;
            this.btnStart.CornerRadius = 3;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.DimGray;
            this.btnStart.Location = new System.Drawing.Point(12, 105);
            this.btnStart.MouseDownBackColor = System.Drawing.Color.Empty;
            this.btnStart.MouseOverBackColor = System.Drawing.Color.Empty;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(260, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "启动Pinping屏保";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.BorderColor = System.Drawing.Color.LightGray;
            this.btnSelectPath.BorderWidth = 1F;
            this.btnSelectPath.CornerRadius = 0;
            this.btnSelectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectPath.ForeColor = System.Drawing.Color.Gray;
            this.btnSelectPath.Location = new System.Drawing.Point(12, 19);
            this.btnSelectPath.MouseDownBackColor = System.Drawing.Color.Empty;
            this.btnSelectPath.MouseOverBackColor = System.Drawing.Color.Empty;
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(260, 40);
            this.btnSelectPath.TabIndex = 0;
            this.btnSelectPath.Text = "点击选择路径";
            this.btnSelectPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSelectPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pinping";
            this.ResumeLayout(false);

        }

        #endregion

        private WinformSample.FlatButton btnSelectPath;
        private WinformSample.FlatButton btnStart;

    }
}