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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flatButton1 = new WinformSample.FlatButton();
            this.customLabel1 = new Frankyu.WinformControls.CustomLabel();
            this.flatButton2 = new WinformSample.FlatButton();
            this.selectionCard1 = new Frankyu.WinformControls.SelectionCard();
            this.btnClose = new WinformSample.FlatButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 33);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 169);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(594, 196);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.ForestGreen;
            this.flatButton1.BorderColor = System.Drawing.Color.Empty;
            this.flatButton1.BorderWidth = 0F;
            this.flatButton1.CornerRadius = 3;
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.ForeColor = System.Drawing.Color.White;
            this.flatButton1.Location = new System.Drawing.Point(79, 474);
            this.flatButton1.MouseDownBackColor = System.Drawing.Color.OliveDrab;
            this.flatButton1.MouseOverBackColor = System.Drawing.Color.Green;
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Size = new System.Drawing.Size(148, 35);
            this.flatButton1.TabIndex = 10;
            this.flatButton1.Text = "确定";
            this.flatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customLabel1
            // 
            this.customLabel1.BackColor = System.Drawing.Color.Transparent;
            this.customLabel1.BorderRadius = 3;
            this.customLabel1.Location = new System.Drawing.Point(247, 385);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(203, 40);
            this.customLabel1.TabIndex = 9;
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.flatButton2.BorderColor = System.Drawing.Color.Red;
            this.flatButton2.BorderWidth = 0.5F;
            this.flatButton2.CornerRadius = 3;
            this.flatButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton2.Location = new System.Drawing.Point(319, 76);
            this.flatButton2.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.flatButton2.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Size = new System.Drawing.Size(116, 28);
            this.flatButton2.TabIndex = 8;
            this.flatButton2.Text = "Add label";
            this.flatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flatButton2.Click += new System.EventHandler(this.flatButton2_Click);
            // 
            // selectionCard1
            // 
            this.selectionCard1.BorderColor = System.Drawing.Color.LightGray;
            this.selectionCard1.BorderRadius = 3;
            this.selectionCard1.BorderWidth = 0.5F;
            this.selectionCard1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.selectionCard1.Image = ((System.Drawing.Image)(resources.GetObject("selectionCard1.Image")));
            this.selectionCard1.ImageWidth = 35;
            this.selectionCard1.IsSelected = false;
            this.selectionCard1.Location = new System.Drawing.Point(34, 74);
            this.selectionCard1.MaximumSize = new System.Drawing.Size(1000, 500);
            this.selectionCard1.Name = "selectionCard1";
            this.selectionCard1.PaddingLeft = 25;
            this.selectionCard1.Size = new System.Drawing.Size(210, 60);
            this.selectionCard1.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.Empty;
            this.btnClose.BorderWidth = 0F;
            this.btnClose.CornerRadius = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.Brown;
            this.btnClose.Location = new System.Drawing.Point(581, 0);
            this.btnClose.MouseDownBackColor = System.Drawing.Color.Empty;
            this.btnClose.MouseOverBackColor = System.Drawing.Color.Empty;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(618, 550);
            this.Controls.Add(this.flatButton1);
            this.Controls.Add(this.customLabel1);
            this.Controls.Add(this.flatButton2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.selectionCard1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(100, 54);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private SelectionCard selectionCard1;
        private WinformSample.FlatButton btnClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private WinformSample.FlatButton flatButton2;
        private CustomLabel customLabel1;
        private WinformSample.FlatButton flatButton1;
    }
}