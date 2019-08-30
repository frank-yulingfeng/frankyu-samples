using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo
{
    public class DemoApp
    {
        public interface IOutput
        {
            void Write(string content);
        }

        public class ConsoleOutput : IOutput
        {
            public void Write(string content)
            {
                Console.WriteLine(content);
            }
        }

        public interface IDateWriter
        {
            void WriteDate();
        }

        public class TodayWriter : IDateWriter
        {
            private IOutput _output;

            public TodayWriter(IOutput output)
            {
                _output = output;
            }

            public void WriteDate()
            {
                _output.Write(DateTime.Today.ToShortDateString());
            }
        }
    }
}
