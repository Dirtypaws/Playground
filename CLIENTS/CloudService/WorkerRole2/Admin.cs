using System.Diagnostics;
using System.Net.Http;
using System.Web.Http;

namespace WorkerRole2
{
    [RoutePrefix("Admin")]
    public class Admin : ApiController
    {
        public Admin()
        {
            Trace.Write("Constructed");
        }

        [HttpGet]
        [Route("Ping")]
        public HttpResponseMessage Ping()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Pong!")
            };
        }
    }
}