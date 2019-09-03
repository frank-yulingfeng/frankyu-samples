using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Security.Principal;

namespace Frankyu.WebApiSample
{
    /// <summary>
    /// 身份认证过滤器
    /// </summary>
    public class BasicAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized, "UNATHORIZED");
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("frank"), null);
            }
        }
    }
}