namespace Frankyu.WinformControls
{
    partial class Form3
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
            this.roundPictureBox2 = new Frankyu.WinformControls.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // roundPictureBox2
            // 
            this.roundPictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundPictureBox2.Location = new System.Drawing.Point(0, 0);
            this.roundPictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.roundPictureBox2.Name = "roundPictureBox2";
            this.roundPictureBox2.Radius = 0;
            this.roundPictureBox2.Size = new System.Drawing.Size(200, 200);
            this.roundPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.roundPictureBox2.TabIndex = 5;
            this.roundPictureBox2.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Controls.Add(this.roundPictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundPictureBox roundPictureBox2;
    }
}