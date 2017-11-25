using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frankyu.EFDemo.Core.Repositories;

namespace Frankyu.EFDemo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
