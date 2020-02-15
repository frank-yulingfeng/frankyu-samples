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

namespace Frankyu.WpfSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            InitializeCommand();
            
        }

        private RoutedCommand _clearCommand = new RoutedCommand("Clear",typeof(Window1));

        private void InitializeCommand()
        {
            this.button1.Command = _clearCommand;
            this._clearCommand.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            //this.button1.CommandTarget = this.txtBox1;
            
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = _clearCommand;
            commandBinding.CanExecute += commandBinding_CanExecute;
            commandBinding.Executed += commandBinding_Executed;

            this.stackPanel.CommandBindings.Add(commandBinding);
        }

        void commandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtBox1.Clear();
            e.Handled = true;
        }

        void commandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(this.txtBox1.Text);
            e.Handled = true;
        }

      
    }
}
