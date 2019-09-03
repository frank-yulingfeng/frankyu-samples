using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Frankyu.WebApiSample.Filter
{

    /// <summary>
    /// API自定义错误过滤器属性
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 统一对调用异常信息进行处理，返回自定义的异常信息
        /// </summary>
        /// <param name="context">HTTP上下文对象</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            //自定义异常的处理
            if (context.Exception is NotImplementedException)
            {
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented)
                //{
                //    //封装处理异常信息，返回指定JSON对象
                //    Content = new StringContent(JsonHelper.ToJson(new ErrorModel((int)HttpStatusCode.NotImplemented, 0, context.Exception.Message)), Encoding.UTF8, "application/json"),
                //    ReasonPhrase = "NotImplementedException"
                //});
            }
            else if (context.Exception is TimeoutException)
            {
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.RequestTimeout)
                //{
                //    //封装处理异常信息，返回指定JSON对象
                //    Content = new StringContent(JsonHelper.ToJson(new ErrorModel((int)HttpStatusCode.RequestTimeout, 0, context.Exception.Message)), Encoding.UTF8, "application/json"),
                //    ReasonPhrase = "TimeoutException"
                //});
            }
            //.....这里可以根据项目需要返回到客户端特定的状态码。如果找不到相应的异常，统一返回服务端错误500
            else
            {
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                //{
                //    //封装处理异常信息，返回指定JSON对象
                //    Content = new StringContent(JsonHelper.ToJson(new ErrorModel((int)HttpStatusCode.InternalServerError, 0, context.Exception.Message)), Encoding.UTF8, "application/json"),
                //    ReasonPhrase = "InternalServerErrorException"
                //});
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
                    
            }

            //记录关键的异常信息
            //NLog.LogManager.GetCurrentClassLogger().Error(context.Exception);
        }
    }
}