using System.Collections.Generic;
using BusinessObjects.Person;

namespace Kendo.LESS.Controllers
{
    public partial class DataHub
    {
        public void UpdatePhone(Phone data)
        {
            Clients.Others.Update(data);
        }

        public Phone CreatePhone(Phone data)
        {
            var phone = _phoneSvc.Create(data);

            Clients.Others.Create(phone);

            return phone;
        }

        public void DeletePhone(Phone data)
        {
            Clients.Others.Delete(data);
        }

        public IEnumerable<Phone> GetPhones()
        {
            var data = _phoneSvc.Get();
            return data;

        }
    }
}