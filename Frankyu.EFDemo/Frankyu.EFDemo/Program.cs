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
            //context.Database.Delete();

            using (UnitOfWork unitOfWork = new UnitOfWork(context))
            {
                //unitOfWork.Admins.Add(new Admin
                //{
                //    AdminName = "mark",
                //    Password = "password",
                //    Type = AdminType.Normal
                //});

                //unitOfWork.Admins.Add(new Admin
                //{
                //    AdminName = "frank",
                //    Password = "abc123",
                //    Type = AdminType.Superior
                //});

                //unitOfWork.Users.Add(new User
                //{
                //    Email = "frankyu@email.com",
                //    UserName = "frankyu",
                //    Password = "mypassword",
                //    UserInfo = new UserInfo
                //    {
                //        Address = "Shenzhen",
                //        Age = 27,
                //        Gender = Gender.Male,
                //        Name = "余凌峰",
                //        PhoneNumber = "110"
                //    },
                //});

                var user = unitOfWork.Users.Get(1);
                //if (user.UserName == "frankyu" && user.UserInfo == null)
                //{
                //    user.UserInfo = new UserInfo
                //    {
                //        Address = "Nanchang",
                //        Age = 26,
                //        Gender = Gender.Male,
                //        Name = "弗兰克",
                //        PhoneNumber = "119"
                //    };
                //}

                unitOfWork.UserInfos.Remove(user.UserInfo);//先删除外键内容
                unitOfWork.Users.Remove(user);
                unitOfWork.Complete();                           
            }

            Console.WriteLine("Completed");
            Console.Read();
        }
    }
}
