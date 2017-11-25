using Frankyu.EFDemo.Core.Model;
using Frankyu.EFDemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.EFDemo.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DemoDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
