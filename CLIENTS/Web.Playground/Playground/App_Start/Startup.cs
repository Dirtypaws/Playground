using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using Playground;

[assembly: OwinStartup(typeof(Startup))]

namespace Playground
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration {EnableDetailedErrors = true};
            //app.MapSignalR(hubConfiguration);
        }
    }
}