using CoreServices.Interfaces;
using CoreServices.Services;
using Microsoft.AspNet.SignalR;

namespace Kendo.LESS.Controllers
{
    public partial class DataHub : Hub
    {
        readonly IPersonService _personSvc;
        readonly IPhoneService _phoneSvc;

        public DataHub() : this(new PersonService(), new PhoneService()) {}

        public DataHub(IPersonService personSvc, IPhoneService phoneSvc)
        {
            _personSvc = personSvc;
            _phoneSvc = phoneSvc;
        }


    }
}