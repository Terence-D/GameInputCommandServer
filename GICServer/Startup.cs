using Owin;
using System.Web.Http;

namespace GICServer
{
    class Startup
    {
        // Configures the Web API. This class is a parameter in the WerbApp.Start method in the main class.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "GicAPi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
