
using Frankyu.EFDemo.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.EFDemo.DataAccess
{
    public class DemoDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<User> Users { get; set; }       
    }
}
