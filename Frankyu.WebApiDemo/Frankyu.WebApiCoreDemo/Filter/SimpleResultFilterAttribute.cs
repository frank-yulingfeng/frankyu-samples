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
    public class SimpleResultFilterAttribute : Attribute, IResultFilter
    {
        private readonly ILogger<SimpleResultFilterAttribute> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory"></param>
        public SimpleResultFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<SimpleResultFilterAttribute>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            logger.LogInformation("ResultFilter Executd!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnResultExecuting(ResultExecutingContext context)
        {
            logger.LogInformation("ResultFilter Executing!");
        }
    }
}
