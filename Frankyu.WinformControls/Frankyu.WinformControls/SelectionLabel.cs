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
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            ReadOnly = true;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            AutoSizeHeight();
        }

        public void AutoSizeHeight()
        {
            if (BorderStyle == System.Windows.Forms.BorderStyle.None
                && !Multiline)
            {
                Multiline = true;
                Size s = TextRenderer.MeasureText(Text, Font, Size.Empty,
                    TextFormatFlags.TextBoxControl);
                MinimumSize = new Size(0, s.Height + 1);
                Multiline = false;
            }
        }    
    }
}
