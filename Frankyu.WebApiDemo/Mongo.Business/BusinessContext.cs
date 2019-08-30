using System;
using System.Collections.Generic;
using System.Text;

namespace Mongo.Business
{
    public class BusinessContext
    {
        public UserBLL UserBLL { get; private set; }

        public BusinessContext(UserBLL userBLL)
        {
            UserBLL = userBLL;
        }
    }
}
