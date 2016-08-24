using System.Collections.Generic;
using BusinessObjects.Person;

namespace Kendo.LESS.Controllers
{
    public partial class DataHub
    {
        public void UpdatePerson(Person data)
        {
            Clients.Others.Update(data);
        }

        public Person CreatePerson(Person data)
        {
            var person = _personSvc.Create(data);

            Clients.Others.Create(person);

            return person;
        }

        public void DeletePerson(Person data)
        {
            Clients.Others.Delete(data);
        }

        public IEnumerable<Person> GetPersons()
        {
            var data = _personSvc.Get();
            return data;

        }

    }
}