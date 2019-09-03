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
    public class SimpleExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogger<SimpleExceptionFilterAttribute> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory"></param>
        public SimpleExceptionFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<SimpleExceptionFilterAttribute>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            logger.LogError("Exception Execute! Message:" + context.Exception.Message);
            context.ExceptionHandled = true;
        }
    }
}
