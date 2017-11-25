using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Frankyu.EFDemo.Core.Model;


namespace Frankyu.EFDemo.DataAccess.Initializer
{
    public class CreateDbIfNotExists 
        : CreateDatabaseIfNotExists<DemoDbContext>
    {
        protected override void Seed(DemoDbContext context)
        {
            var admins = new List<Admin> 
            { 
                new Admin { AdminName="Frank Yu", Password="abc123", Type= AdminType.Superior},
                new Admin{AdminName="Sam Yu",Password="FrankYu",Type= AdminType.Superior},
                new Admin{AdminName="Mark Pig",Password="piggy",Type = AdminType.Normal},
            };

            context.Admins.AddRange(admins);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
