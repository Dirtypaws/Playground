using System.Collections.Generic;
using BusinessObjects.Person;
using CoreServices.Interfaces;
using CoreServices.Services;
using Microsoft.AspNet.SignalR;

namespace Kendo.LESS.Controllers
{
    public class DataHub : Hub
    {
        readonly IPersonService _personSvc;

        public DataHub() : this(new PersonService()) {}

        public DataHub(IPersonService personSvc)
        {
            _personSvc = personSvc;
        }

        public void Update(Person data)
        {
            Clients.Others.Update(data);
        }

        public Person Create(Person data)
        {
            var person = _personSvc.Create(data);

            Clients.Others.Create(person);

            return person;
        }

        public void Delete(Person data)
        {
            Clients.Others.Delete(data);
        }

        public IEnumerable<Person> Get()
        {
            var data = _personSvc.Get();
            return data;

        }
    }
}