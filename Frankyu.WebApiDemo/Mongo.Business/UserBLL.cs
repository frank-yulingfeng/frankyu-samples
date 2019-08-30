using System;
using System.Collections.Generic;
using Mongo.DataAccess;
using Mongo.Models;

namespace Mongo.Business
{
    public class UserBLL : BaseBLL<User>
    {
        public UserBLL(CommonDAL<User> commonDAL)
            : base(commonDAL)
        {
        }      
    }
}
