using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Frankyu.WebApiSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ModelActionFilter());

            // Create a message handler chain with an end-point.
            var routeHandlers = HttpClientFactory.CreatePipeline(
                new HttpControllerDispatcher(config), new[] { new ApiKeyHandler("ping") });

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null,//该参数是什么?约束？
                handler: routeHandlers
            );

            //添加全局 消息处理器（MessageHandler）会在收到请求时就对该消息请求进行验证
            //config.MessageHandlers.Add(new ApiKeyHandler("frank"));
        }
    }
}
