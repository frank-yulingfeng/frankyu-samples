using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Frankyu.WebApiCoreDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
            })
            .AddXmlSerializerFormatters()
            .AddXmlDataContractSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

#if DEBUG
            //配置Swagger
            services.AddSwaggerGen(c =>
            {
                InitSwaggerGen(c);
            });
#endif
        }

        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

#if DEBUG
            //配置Swagger
            app.UseStaticFiles(); //静态文件服务
            app.UseSwagger(); // 使用Swagger
            app.UseSwaggerUI(c =>
            {
                InitSwaggerUI(c);
            });
#endif
        }

        private void InitSwaggerGen(SwaggerGenOptions swaggerGenOptions)
        {
            string apiName = "WOTRUS";

            typeof(Swagger.ApiVersions).GetEnumNames().ToList().ForEach(version =>
            {
                swaggerGenOptions.SwaggerDoc(version, new Info
                {
                    // {ApiName} 定义成全局变量，方便修改
                    Version = version,
                    Title = $"{apiName} 接口文档",
                    Description = $"{apiName} HTTP API " + version,
                    TermsOfService = "None",
                });
                //API注释xml文档生成路径
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath + "Frankyu.WebApiCoreDemo.xml");
                swaggerGenOptions.IncludeXmlComments(xmlPath);
            });
        }

        private void InitSwaggerUI(SwaggerUIOptions swaggerUIOptions)
        {
            typeof(Swagger.ApiVersions).GetEnumNames().ToList().ForEach(version =>
            {
                swaggerUIOptions.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"WoTrus API {version}");
            });
        }
    }
}
