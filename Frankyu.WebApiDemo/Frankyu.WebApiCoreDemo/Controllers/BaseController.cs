﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Business;
using NLog;

namespace Frankyu.WebApiCoreDemo.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private ILogger logger;

        /// <summary>
        /// 记录Log对象
        /// </summary>
        protected ILogger Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = LogManager.GetLogger(GetType().FullName);
                }

                return logger;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected BusinessContext DbContext { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessContext"></param>
        public BaseController(BusinessContext businessContext)
        {
            DbContext = businessContext;
        }
    }
}