using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frankyu.EFDemo.DataAccess;
using Frankyu.EFDemo.Core.Model;

namespace Frankyu.EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new DemoDbContext()))
            {
                /*unitOfWork.Admins.Add(new Admin
                {
                    AdminName = "mark",
                    Password = "markisapig",
                    Type = AdminType.Normal
                });

                unitOfWork.Users.Add(new User
                {
                    Email = "abc@emal.com",
                    Password = "what",
                    UserName = "balbdfs",
                    Age = 29,
                });

                unitOfWork.Complete();*/

                var allAdmin = unitOfWork.Admins.GetAll();

                foreach (var admin in allAdmin)
                {
                    Console.WriteLine(admin.AdminName + " is " + admin.Type.ToString() +" administrator");
                }

            }    
            Console.Read();
        }
    }
}
