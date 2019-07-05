using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Frankyu.WinformControls
{
    public class TabButtonCollection
    {
        private List<TabButton> _tabButtons;

        public TabButtonCollection(List<TabButton> tabButtons)
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

        /// <summary>
        /// 自动水平布局
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="spacing"></param>
        /// <param name="autoSize"></param>
        public void AutoLayout(Point startPoint, int spacing = 0, bool autoSize = false)
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

        /// <summary>
        /// 自动垂直布局
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="spacing"></param>
        public void AutoVericalLayoutVerical(Point startPoint, int spacing = 0)
        {
            foreach (var tab in _tabButtons)
            {
                tab.Location = startPoint;
                startPoint = startPoint + new Size(0, tab.Height + spacing);
            }
        }

        /// <summary>
        /// 设置集合属性
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void SetProperty(string propertyName, object value)
        {
            foreach (var tab in _tabButtons)
            {
                try
                {
                    var propertyInfo = typeof(TabButton).GetProperty(propertyName);
                    propertyInfo.SetValue(tab, value, null);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
