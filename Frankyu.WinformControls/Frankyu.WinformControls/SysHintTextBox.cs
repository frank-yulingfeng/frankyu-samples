using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Frankyu.WinformControls
{
    public class SysHintTextBox : TextBox
    {
        /* MutilLine 为 false时，此属性才有效*/
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        private static extern Int32 SendMessage(IntPtr hWnd, int msg,
                   int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetHintText(Control control, string text)
        {
            SendMessage(control.Handle, 0x1501, 0, text);
        }

        private string _hint = string.Empty;

        public string Hint
        {
            get { return _hint; }
            set
            {
                _hint = value;
                SetHintText(this, _hint);
            }
        }
        
        public SysHintTextBox() : base()
        {

        }        
    }
}
