namespace WindowsFormsApplication1
{
    partial class HintTextBox
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbox = new System.Windows.Forms.TextBox();
            this.lbHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbox
            // 
            this.txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox.Location = new System.Drawing.Point(3, 23);
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(280, 13);
            this.txtbox.TabIndex = 0;
            // 
            // lbHint
            // 
            this.lbHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHint.AutoSize = true;
            this.lbHint.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbHint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbHint.ForeColor = System.Drawing.Color.DimGray;
            this.lbHint.Location = new System.Drawing.Point(19, 23);
            this.lbHint.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(24, 13);
            this.lbHint.TabIndex = 1;
            this.lbHint.Text = "hint";
            this.lbHint.Click += new System.EventHandler(this.lbHint_Click);
            // 
            // HintTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbHint);
            this.Controls.Add(this.txtbox);
            this.Name = "HintTextBox";
            this.Size = new System.Drawing.Size(300, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.Label lbHint;
    }
}
