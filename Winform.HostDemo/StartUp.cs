using Owin;
using System.Web.Http;

namespace Winform.HostDemo
{
    public class StartUp
    {
        // 该方法由 OWIN 主机在启动时调用
        // 此方法名称必须为 “Configuration”
        public void Configuration(IAppBuilder appBuilder)
        {
            // 配置代码可以放在这里

            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes(); // 启用特性路由

            // 启用 Web API 路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 将 Web API 中间价集成到 OWIN 管道中
            appBuilder.UseWebApi(config);
        }
    }
}
