using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Frankyu.WinformControls
{
    public class SelectionLabel : TextBox
    {
        public SelectionLabel() :
            base()
        {
            BorderStyle = BorderStyle.None;
            ReadOnly = true;
            SetCaret(this);

            //this.MouseMove += new MouseEventHandler(MouseHideCaret);
            this.MouseUp += new MouseEventHandler(MouseHideCaret);
            this.MouseDown += new MouseEventHandler(MouseHideCaret);
            this.MouseClick += new MouseEventHandler(MouseHideCaret);
            this.MouseDoubleClick += new MouseEventHandler(MouseHideCaret);            
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            AutoSizeHeight();
        }

        public void AutoSizeHeight()
        {
            if (BorderStyle == BorderStyle.None
                && !Multiline)
            {
                Multiline = true;
                Size s = TextRenderer.MeasureText(Text, Font, Size.Empty,
                    TextFormatFlags.TextBoxControl);
                MinimumSize = new Size(0, s.Height + 1);
                Multiline = false;
            }
        }

        #region 光标

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowCaret(IntPtr hWnd);

        private bool hideCaret = true;

        public bool HideCaretP
        {
            get
            {
                return hideCaret;
            }
            set
            {
                hideCaret = value;
            }
        }       

        void MouseHideCaret(object sender, MouseEventArgs e)
        {
            SetCaret(sender as TextBox);
        }

        void SetCaret(TextBox textbox)
        {
            if (HideCaretP)
            {
                HideCaret(textbox.Handle);
            }
            else
            {
                ShowCaret(textbox.Handle);
            }
        }

        ///// <summary>
        ///// 防止控件闪烁
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}

        #endregion
    }
}
