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
    }
}
