using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frankyu.WebApiCoreDemo.Swagger
{
    /// <summary>
    /// api版本控制，只是给接口版本标识，不改变请求路由
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ApiVersionsAttribute : ApiExplorerSettingsAttribute
    {
        /// <summary>
        /// 版本控制
        /// </summary>
        /// <param name="apiVersion"></param>
        public ApiVersionsAttribute(ApiVersions apiVersion)
            : base()
        {
            GroupName = apiVersion.ToString();
        }
    }
}
