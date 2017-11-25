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
            //Database.SetInitializer<DemoDbContext>(new CreateDbIfNotExists());
            using (UnitOfWork unitOfWork = new UnitOfWork(new DemoDbContext()))
            {
                unitOfWork.Admins.Add(new Admin
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
                    Gender = Gender.Female
                });

                unitOfWork.Complete();

                var allAdmin = unitOfWork.Admins.GetAll();

                //foreach (var admin in allAdmin)
                //{
                //    Console.WriteLine(admin.AdminName + " is " + admin.Type.ToString() +" administrator");

                //    admin.Password = "fuckpassword";
                //}

                //unitOfWork.Complete();
            
            }

            Console.WriteLine("Completed");
            Console.Read();
        }
    }
}
