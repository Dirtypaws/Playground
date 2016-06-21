using System.Web.Http;
using Owin;

namespace WorkerRole2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {


            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute
                (
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new
                    {
                        id = RouteParameter.Optional
                    }
                );

            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        }
    }
}