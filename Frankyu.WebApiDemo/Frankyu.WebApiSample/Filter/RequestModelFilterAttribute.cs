using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace Frankyu.WebApiSample.Filter
{
    public class RequestModelFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 接口请求前验证数据
        /// </summary>
        /// <param name="actionContext">上下文</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                // Return the validation errors in the response body.
                // 在响应体中返回验证错误信息
                var errors = new Dictionary<string, IEnumerable<string>>();
                foreach (KeyValuePair<string, ModelState> keyValue in actionContext.ModelState)
                {
                    errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage);
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    RequestArgError = errors//显示验证错误的信息
                });
            }
        }
    }
}