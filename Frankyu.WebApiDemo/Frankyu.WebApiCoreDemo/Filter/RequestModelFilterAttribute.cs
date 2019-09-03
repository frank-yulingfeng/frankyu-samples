
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frankyu.WebApiCoreDemo.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestModelFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 接口请求前验证数据
        /// </summary>
        /// <param name="actionContext">上下文</param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                // Return the validation errors in the response body.
                // 在响应体中返回验证错误信息
                //var errors = new Dictionary<string, IEnumerable<string>>();
                //foreach (var keyValue in actionContext.ModelState)
                //{
                //    errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage);
                //}
                //actionContext.Result = new JsonResult(errors);              
            }
        }
    }
}
