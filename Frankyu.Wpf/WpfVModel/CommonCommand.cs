using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfVModel
{
    public class CommonCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private Predicate<object> canExecute;

        private Action<object> doExecute;

        public CommonCommand(
            Action<object> executeAction,
            Predicate<object> canExecuteAction = null)
        {
            doExecute = executeAction;
            canExecute = canExecuteAction;
        }

        public void OnCanExecuteChanged()//OnCanExecute方法
        {
            EventHandler handler = this.CanExecuteChanged;
            if (handler != null)
            {
                //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;

            return canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            if (doExecute != null)
            {
                doExecute.Invoke(parameter);
            }
        }
    }
}
