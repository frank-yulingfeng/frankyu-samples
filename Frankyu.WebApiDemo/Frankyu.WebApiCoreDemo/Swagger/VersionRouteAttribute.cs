
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;

namespace Frankyu.WebApiCoreDemo.Swagger
{
    /// <summary>
    /// 自定义路由，实现版本控制，在请求路由中带上接口版本
    /// /api/{version}/[controler]/[action] 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class VersionRouteAttribute : RouteAttribute, IApiDescriptionGroupNameProvider
    { 
        /// <summary>
        /// 分组名称,是来实现接口 IApiDescriptionGroupNameProvider 
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 自定义路由构造函数，继承基类路由，默认版本v1
        /// </summary>
        /// <param name="actionName">方法名</param>
        public VersionRouteAttribute(string actionName = "[action]")
            : base($"/api/{ApiVersions.v1.ToString()}/[controller]/" + actionName)
        {
        }
        
        /// <summary>
        /// 自定义版本+路由构造函数，继承基类路由
        /// <param name="actionName"></param>
        /// <param name="version"></param>
        public VersionRouteAttribute(ApiVersions version, string actionName = "[action]") 
            : base($"/api/{version.ToString()}/[controller]/{actionName}")
        {
            GroupName = version.ToString();
        }
    }
}
