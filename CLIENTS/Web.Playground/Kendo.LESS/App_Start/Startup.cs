
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Kendo.LESS.Startup))]

namespace Kendo.LESS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration {EnableDetailedErrors = true};
            app.MapSignalR(hubConfiguration);
        }
    }
}