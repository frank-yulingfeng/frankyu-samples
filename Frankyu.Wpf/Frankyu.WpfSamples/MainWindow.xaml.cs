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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfVModel;

namespace Frankyu.WpfSamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainVModel vModel;


        public MainWindow()
        {
            InitializeComponent();
            vModel = base.DataContext as MainVModel;

            vModel.Name = "Frank YU";

            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;            
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                if (this.WindowState == System.Windows.WindowState.Maximized)
                    WindowState = System.Windows.WindowState.Normal;
                this.DragMove();
            }
        }
        

        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
            args.Handled = true;
        }

        private void New_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            MessageBox.Show("You add a new " + args.Parameter.ToString());
            args.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


       
    }
}
