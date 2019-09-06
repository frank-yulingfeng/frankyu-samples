using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// PreviewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PreviewWindow : Window
    {
        public PreviewWindow(Canvas canvas)
        {
            InitializeComponent();

            Title = "签章预览";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (canvas != null)
            {
                mainGrid.Children.Add(canvas);
            }
            this.Closing += PreviewWindow_Closing;         
        }

        private void PreviewWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainGrid.Children.Clear();
        }
    }
}
