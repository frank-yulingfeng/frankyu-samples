using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frankyu.WebApiCoreDemo.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class SimpleResourceFilterAttribute : Attribute, IResourceFilter
    {
        private readonly ILogger<SimpleResourceFilterAttribute> logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="loggerFactory"></param>
        public SimpleResourceFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<SimpleResourceFilterAttribute>();
        }

        /// <summary>
        /// 执行后
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            logger.LogInformation("ResourceFilter Executed!");
        }

        /// <summary>
        /// 执行时
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            logger.LogInformation("ResourceFilter Executing!");
        }
    }
}
