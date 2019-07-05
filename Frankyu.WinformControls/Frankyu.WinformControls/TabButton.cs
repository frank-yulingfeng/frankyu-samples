
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public partial class TabButton : UserControl
    {
        /// <summary>
        /// 选中时下划线颜色
        /// </summary>
        public Color SelectedLineColor { get; set; }

        /// <summary>
        /// 选中时下划线颜色
        /// </summary>
        public Color UnselectedLineColor { get; set; }

        private int _horizonPadding = 10;

        public int HorizonPadding
        {
            get { return _horizonPadding; }
            set
            {
                if (_horizonPadding == value)
                    return;

                _horizonPadding = value;
                Invalidate();
            }
        }

        private int _vericalPadding = 10;

        public int VericalPadding
        {
            get { return _vericalPadding; }
            set
            {
                if (_vericalPadding == value)
                    return;

                _vericalPadding = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 选中时文本颜色
        /// </summary>
        public Color SelectedForeColor { get; set; }

        private SelectedLineLocation _lineLocation = SelectedLineLocation.Bottom;
        public SelectedLineLocation LineLocation
        {
            get { return _lineLocation; }
            set
            {
                _lineLocation = value;
                Invalidate();
            }
        }

        private bool _isSelected = false;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value)
                    return;

                _isSelected = value;
                Invalidate();
            }
        }
        
        public string TabText
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }

            set
            {
                base.AutoSize = value;
                AutoSizeWidth();
                Invalidate();
            }
        }

        private float _lineWidth = 3f;

        public float LineWidth
        {
            get { return _lineWidth; }
            set
            {
                _lineWidth = value;
                Invalidate();
            }
        }

        private float _unselectedLineWidth = 3f;

        public float UnselectedLineWidth
        {
            get { return _unselectedLineWidth; }
            set
            {
                _unselectedLineWidth = value;
                Invalidate();
            }
        }


        public StringAlignment TextAlignment { get; set; }

        /// <summary>
        /// 页签按键
        /// </summary>
        public TabButton()
        {
            InitializeComponent();
            SelectedForeColor = ForeColor;
            SelectedLineColor = BackColor;
            UnselectedLineColor = BackColor;
            TextAlignment= StringAlignment.Center;
            this.Cursor = Cursors.Hand;
            TabText = "Tab Button";            
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            //IsSelected = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);            

            //写文字
            var g = e.Graphics;
            var color = _isSelected ? SelectedForeColor : ForeColor;
            var stringFormat = new StringFormat
            {
                Alignment = TextAlignment,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };
            
            var rect = new RectangleF
            {
                X = HorizonPadding,
                Y = VericalPadding,
                Width = this.Width - 2 * HorizonPadding,
                Height = this.Height - 2 * VericalPadding,
            };
            g.DrawString(TabText, Font, new SolidBrush(color), rect, stringFormat);
            
            var lineWidth = IsSelected ? LineWidth : UnselectedLineWidth;
            if (lineWidth <= 0)
                return;

            var penColor = IsSelected ? SelectedLineColor : UnselectedLineColor;
            var pen = new Pen(penColor, lineWidth);

            switch (LineLocation)
            {
                case SelectedLineLocation.Bottom:
                    g.DrawLine(pen, new Point(0, Height - 1), new Point(Width, Height - 1));
                    break;
                case SelectedLineLocation.Left:
                    g.DrawLine(pen, new Point(1, 0), new Point(1, Height));
                    break;
                case SelectedLineLocation.Right:
                    g.DrawLine(pen, new Point(Width - 1, 0), new Point(Width - 1, Height));
                    break;
            }
        }

        /// <summary>
        /// 根据文本自动计算长度, 最小为50
        /// </summary>
        private void AutoSizeWidth()
        {
            if (string.IsNullOrEmpty(TabText))                
            {
                Width = 50;
                return;
            }

            Graphics graphics = CreateGraphics();
            SizeF textSize = graphics.MeasureString(TabText, Font);

            this.Width = (int)textSize.Width + 20;
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
    }

    public enum SelectedLineLocation
    {
        Bottom,
        Left,
        Right
    }
}
