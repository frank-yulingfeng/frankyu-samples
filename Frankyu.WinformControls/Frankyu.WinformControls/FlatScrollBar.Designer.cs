namespace Frankyu.WinformControls
{
    partial class FlatScrollBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScrollContainer = new System.Windows.Forms.Panel();
            this.ScrollAt = new System.Windows.Forms.Panel();
            this.ScrollContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollContainer
            // 
            this.ScrollContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ScrollContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScrollContainer.Controls.Add(this.ScrollAt);
            this.ScrollContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrollContainer.Location = new System.Drawing.Point(0, 0);
            this.ScrollContainer.Name = "ScrollContainer";
            this.ScrollContainer.Size = new System.Drawing.Size(20, 257);
            this.ScrollContainer.TabIndex = 0;
            // 
            // ScrollAt
            // 
            this.ScrollAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollAt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.ScrollAt.Location = new System.Drawing.Point(1, 1);
            this.ScrollAt.Name = "ScrollAt";
            this.ScrollAt.Size = new System.Drawing.Size(16, 20);
            this.ScrollAt.TabIndex = 0;
            // 
            // FlatScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ScrollContainer);
            this.Name = "FlatScrollBar";
            this.Size = new System.Drawing.Size(20, 257);
            this.ScrollContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ScrollContainer;
        private System.Windows.Forms.Panel ScrollAt;
    }
}
