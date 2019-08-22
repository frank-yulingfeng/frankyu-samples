
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class HintTextBox : UserControl
    {
        private readonly Color Color_LostFocus = Color.LightGray;
        private readonly Color Color_GotFocus = Color.FromArgb(72, 142, 231);

        private Color _colorBorder;

        private int _borderRadius = 0;
        public int BorderRadius
        {
            get { return _borderRadius; }
            set 
            {
                _borderRadius = value;
                SetRound();
            }
        }

        public string HintText
        {
            get { return lbHint.Text; }
            set { lbHint.Text = value; }
        }

        public new string Text
        {
            get { return txtbox.Text; }

            set { txtbox.Text = value; }
        }

        public char PasswordChar
        {
            get { return txtbox.PasswordChar; }
            set { txtbox.PasswordChar = value; }
        }

        public new bool Enabled
        {
            get { return txtbox.Enabled; }
            set
            {
                txtbox.Enabled = value;
                lbHint.Enabled = value;
            }
        }       

        public bool HightLight { get; set; }

        private float _borderWidth = 0;
        public float BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                if (value < 0)
                {
                    _borderWidth = 0;
                    return;
                }

                _borderWidth = value;
                SetRound();
            }
        }

        private Color _borderColor;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                if (HightLight)
                {
                    _colorBorder = BorderColor.IsEmpty ? Color_LostFocus : BorderColor;
                }
                Invalidate();
            }
        }

        private Color _highLightBorderColor;

        public Color HighLightBorderColor
        {
            get
            {
                return _highLightBorderColor;
            }
            set
            {
                _highLightBorderColor = value;
                Invalidate();
            }
        }

        public HintTextBox()
        {
            InitializeComponent();
            this.txtbox.BackColor = BackColor;            
            this.lbHint.BackColor = Color.Transparent;

            this.Paint += CustomTextBox_Paint;
            this.txtbox.GotFocus += Txtbox_GotFocus;
            this.txtbox.LostFocus += Txtbox_LostFocus;
            this.txtbox.TextChanged += Txtbox_TextChanged;
            this.FontChanged += HintTextBox_FontChanged;
            this.BackColorChanged += HintTextBox_BackColorChanged;
            
            BorderWidth = 1f;
            RefreshFont();           
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetRound();
        }

        private void HintTextBox_Load(object sender, EventArgs e)
        {
            if (HightLight)
            {
                _colorBorder = BorderColor.IsEmpty ? Color_LostFocus : BorderColor;
                Invalidate();
            }
        }

        void HintTextBox_BackColorChanged(object sender, EventArgs e)
        {
            this.txtbox.BackColor = BackColor;
        }

        void HintTextBox_FontChanged(object sender, EventArgs e)
        {
            RefreshFont();
        }       

        /// <summary>
        /// 防止控件闪烁
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Txtbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbox.Text))
            {
                lbHint.Visible = true;
            }
            else
            {
                lbHint.Visible = false;
            }
        }

        private void Txtbox_LostFocus(object sender, EventArgs e)
        {
            if (HightLight)
            {
                _colorBorder = BorderColor.IsEmpty ? Color_LostFocus : BorderColor;
                this.Invalidate();
            }
        }

        private void Txtbox_GotFocus(object sender, EventArgs e)
        {
            if (HightLight)
            {
                _colorBorder = HighLightBorderColor.IsEmpty ? Color_GotFocus : HighLightBorderColor;
                this.Invalidate();
            }
        }

        private void CustomTextBox_Paint(object sender, PaintEventArgs e)
        {
            if (!HightLight)
            {
                _colorBorder = BorderColor.IsEmpty ? Color_LostFocus : BorderColor;
            }

            if (BorderWidth <= 0)
                return;

            Pen pen = new Pen(_colorBorder, BorderWidth);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;//消除锯齿
            DrawRoundRect(e.Graphics, pen, new Point(0, 0), Width - 1, Height - 1, BorderRadius);
        }       

        /// <summary>
        /// 画圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="point"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void DrawRoundRect(Graphics g,
            Pen pen, Point point,
            int width, int height, int radius = 0)
        {
            //圆角半径不能大于长或宽的一半
            if (radius > width / 2 || radius > height / 2)
                radius = 0;

            var size = new Size(radius * 2, radius * 2);

            var pLeftUp = point;
            var pLeftDown = point + new Size(0, height);
            var pRightUp = point + new Size(width, 0);
            var pRightDown = point + new Size(width, height);

            //画出一个大的矩形
            g.DrawLine(pen, pLeftUp.X, pLeftUp.Y + radius, pLeftDown.X, pLeftDown.Y - radius);
            g.DrawLine(pen, pLeftUp.X + radius, pLeftUp.Y, pRightUp.X - radius, pRightUp.Y);
            g.DrawLine(pen, pRightDown.X, pRightDown.Y - radius, pRightUp.X, pRightUp.Y + radius);
            g.DrawLine(pen, pRightDown.X - radius, pRightDown.Y, pLeftDown.X + radius, pLeftDown.Y);

            if (radius == 0)
                return;

            //画四个圆角
            var rect1 = new Rectangle(pLeftUp, size);
            g.DrawArc(pen, rect1, 180, 90);
            var rect2 = new Rectangle(new Point(pLeftDown.X, pLeftDown.Y - size.Width), size);
            g.DrawArc(pen, rect2, 90, 90);
            var rect3 = new Rectangle(new Point(pRightUp.X - size.Width, pRightUp.Y), size);
            g.DrawArc(pen, rect3, 270, 90);
            var rect4 = new Rectangle(new Point(pRightDown.X - size.Width, pRightDown.Y - size.Width), size);
            g.DrawArc(pen, rect4, 0, 90);
        }

        /// <summary>
        /// 设置输入文字大小
        /// </summary>
        /// <param name="size"></param>
        private void RefreshFont()
        {
            txtbox.Font = this.Font;
            lbHint.Font = this.Font;
            lbHint.ForeColor = Color.DarkGray;
            RefreshHeight(txtbox);

            var y = (Height - txtbox.Height) / 2;
            txtbox.Location = new Point(8, y);
            txtbox.Width = Width - 16;

            y = (Height - lbHint.Height) / 2;
            lbHint.Location = new Point(9, y - 1);
        }

        private void RefreshHeight(TextBox textbox)
        {
            textbox.Multiline = true;
            Size s = TextRenderer.MeasureText(textbox.Text, textbox.Font, Size.Empty,
                TextFormatFlags.TextBoxControl);
            textbox.MinimumSize = new Size(0, s.Height + 1);
            textbox.Multiline = false;
        }    

        private void lbHint_Click(object sender, EventArgs e)
        {
            this.txtbox.Focus();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );

        private void SetRound()
        {
            var corerRadius = BorderRadius + (BorderWidth > 0 ? 2 : 0);
            IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, corerRadius, corerRadius);
            Region = Region.FromHrgn(ptr);
        }       
    }
}
