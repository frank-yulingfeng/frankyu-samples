using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Frankyu.WebApiCoreDemo.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class SimpleActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly ILogger<SimpleActionFilterAttribute> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory"></param>
        public SimpleActionFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<SimpleActionFilterAttribute>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("ActionFilter Executed!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("ActionFilter Executing!");
        }
    }
}
