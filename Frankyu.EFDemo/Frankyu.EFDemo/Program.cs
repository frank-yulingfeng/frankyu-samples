using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frankyu.EFDemo.DataAccess;
using Frankyu.EFDemo.Core.Model;
using System.Data.Entity;
using Frankyu.EFDemo.DataAccess.Initializer;

namespace Frankyu.EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoDbContext context = new DemoDbContext();

            using (UnitOfWork unitOfWork = new UnitOfWork(context))
            {
                var admins = unitOfWork.Admins.GetAll();

                foreach (var admin in admins)
                {
                    Console.WriteLine(admin.AdminName + ":" + admin.Password);
                }
            }

            Console.WriteLine("Completed");
            Console.Read();
        }
    }
}
