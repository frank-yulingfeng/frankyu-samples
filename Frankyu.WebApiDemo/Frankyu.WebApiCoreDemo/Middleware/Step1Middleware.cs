using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frankyu.WebApiCoreDemo.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class Step1Middleware
    {
        private readonly RequestDelegate _next;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public Step1Middleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            //await context.Response.WriteAsync("Hello Step one!");
            //await _next(context);//只有调用该方法，请求才会往下走，不然就会直接返回给客户端
        }
    }
}
