using Frankyu.EFDemo.Core;
using Frankyu.EFDemo.Core.Repositories;
using Frankyu.EFDemo.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.EFDemo.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoDbContext _context;

        private IAdminRepository _admins;
        private IUserRepository _users;
        private IUserInfoRepository _userInfos;

        public UnitOfWork(DemoDbContext dbContext)
        {
            _context = dbContext;

            _admins = new AdminRepository(_context);
            _users = new UserRepository(_context);
            _userInfos = new UserInfoRepository(_context);
        }

        public IAdminRepository Admins
        {
            get { return _admins; }
        }

        public IUserRepository Users
        {
            get { return _users; }
        }

        public IUserInfoRepository UserInfos
        {
            get { return _userInfos; }
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
