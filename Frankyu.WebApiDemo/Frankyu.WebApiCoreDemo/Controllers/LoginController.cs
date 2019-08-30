using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mongo.Business;
using Mongo.Models;
using MongoDB.Driver;

namespace Frankyu.WebApiCoreDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessContext"></param>
        public LoginController(BusinessContext businessContext)
            : base(businessContext)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AddUser")]
        public ActionResult<bool> AddUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            var user = new Mongo.Models.User
            {
                _id = Guid.NewGuid().ToString(),
                UserName = username,
                Password = password,
                CreateTime = DateTime.Now
            };
            DbContext.UserBLL.Insert(user);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserPassword")]
        public ActionResult<string> GetUserPassword(string username)
        {
            var update = Builders<User>.Update.Set(a => a.Password, "changed");
            var user = DbContext.UserBLL.FindAndUpdate(r => r.UserName == username, update);
            return user?.Password;
        }
    }
}
