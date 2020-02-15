using Frankyu.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.DataAccess
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        public SchoolContext()
            : base()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolContext>());
        }

        public SchoolContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Moved all Student related configuration to StudentEntityConfiguration class
            modelBuilder.Configurations.Add(new StudentConfigurations());

        }
    }
}
