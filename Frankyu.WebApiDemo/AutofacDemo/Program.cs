using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutofacDemo
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DemoApp.ConsoleOutput>().As<DemoApp.IOutput>();
            builder.RegisterType<DemoApp.TodayWriter>().As<DemoApp.IDateWriter>();

            Container = builder.Build();

            WriteDate();

            Console.Read();
        }

        public static void WriteDate()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<DemoApp.IDateWriter>();
                writer.WriteDate();
            }
        }
    }
}
