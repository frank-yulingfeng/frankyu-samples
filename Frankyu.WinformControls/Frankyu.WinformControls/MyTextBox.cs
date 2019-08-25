using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public class MyTextBox : TextBox
    {
        private const int EM_GETLINECOUNT = 0xBA;

        /// <summary>
        /// 文本行数
        /// </summary>
        public int GetLineCount()
        {
            Message msg = Message.Create(this.Handle, EM_GETLINECOUNT, IntPtr.Zero, IntPtr.Zero);
            base.DefWndProc(ref msg);
            return msg.Result.ToInt32();
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
        
        #endregion
    }
}
