using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfVModel
{
    public class MainVModel : VModelBase
    {
        #region 属性

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Age { get; set; }

        public string PhoneNum { get; set; }

        public string Address { get; set; }

        #endregion

        #region Command

        public ICommand ShowNameCommand { get; set; }

        private void Show(object name)
        {
            Name = name.ToString(); 
        }

        #endregion

        public MainVModel()
        {
            ShowNameCommand = new CommonCommand(Show);
        }
    }
}
