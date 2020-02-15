using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Frankyu.WpfSamples
{
    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source)
            : base(routedEvent, source)
        {

        }

        public DateTime ClickTime { get; set; }
    }
}
