using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Frankyu.WinformControls
{
    public class TabButtonManager
    {
        private List<TabButton> _tabButtons;

        public TabButtonManager(List<TabButton> tabButtons)
        {
            _tabButtons = tabButtons;

            foreach (var tab in _tabButtons)
            {
                tab.Click += Tab_Click;
            }
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            SetSelectedTab((TabButton)sender);
        }

        private void SetSelectedTab(TabButton tabButton)
        {
            if (tabButton == null || _tabButtons?.Count == 0)
                return;            

            foreach (var tab in _tabButtons)
            {
                tab.IsSelected = false;
            }

            tabButton.IsSelected = true;
        }

        public void AutoLayout(Point startPoint, bool autoSize = false, int spacing = 0)
        {
            foreach (var tab in _tabButtons)
            {
                if (autoSize)
                {
                    tab.AutoSize = true;
                }

                tab.Location = startPoint;
                startPoint = startPoint + new Size(tab.Width + spacing, 0);
            }
        }
    }
}
