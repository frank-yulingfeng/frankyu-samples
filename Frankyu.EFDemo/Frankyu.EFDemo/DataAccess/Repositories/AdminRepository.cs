using Frankyu.EFDemo.Core.Model;
using Frankyu.EFDemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.EFDemo.DataAccess.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private DbSet<Admin> _dbSet
        {
            get
            {
                return (_dbContext as DemoDbContext).Admins;
            }
        }

        public AdminRepository(DemoDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<Admin> GetByAdminType(AdminType type)
        {
            return _dbSet.Where(a => a.Type == type);
        }
    }
}
