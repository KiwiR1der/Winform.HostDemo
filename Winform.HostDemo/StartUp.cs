using Owin;
using Swashbuckle.Application;
using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Winform.HostDemo
{
    public class StartUp
    {
        // 该方法由 OWIN 主机在启动时调用
        // 此方法名称必须为 “Configuration”
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            // --- 优化 A: 设置 JSON 为默认格式，移除 XML ---
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            // 解决 JSON 循环引用问题（可选，但推荐）
            // config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // --- 优化 B: 启用 Swagger 并加载注释 ---
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Winform.HostDemo API");

                // 读取 XML 注释
                // 注意：请确保项目属性->生成中勾选了"XML文档文件"
                var xmlPath = GetXmlCommentsPath();
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            })
            .EnableSwaggerUi(c =>
            {
                // 可选：禁用底部的 "Validator" 链接（内网环境如果不禁用可能会加载变慢）
                c.DisableValidator();
            });

            // 启用特性路由 (如 [RoutePrefix], [Route])
            config.MapHttpAttributeRoutes();

            // 启用约定路由 (默认路由)
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }

        // 辅助方法：动态获取 XML 文件路径
        private static string GetXmlCommentsPath()
        {
            // 获取当前应用程序的基础目录
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // 请将 "Winform.HostDemo.XML" 替换为你实际生成的 XML 文件名
            return Path.Combine(baseDirectory, "Winform.HostDemo.XML");
        }
    }
}
