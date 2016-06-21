using System;
using System.Collections.Generic;
using BusinessObjects;
using Microsoft.AspNet.SignalR;

namespace Kendo.LESS.Controllers
{
    public class DataHub : Hub
    {
        readonly List<Data> data = new List<Data>
            {
                new Data {ID = Guid.NewGuid(), InStock = true, Name = "Test Product", Price = 0}
            };

        public void Update(Data data)
        {
            Clients.Others.Update(data);
        }

        public Data Create()
        {
            var newData = new Data {ID = Guid.NewGuid(), InStock = true, Name = "Test Product -2 ", Price = 0};
            data.Add(newData);
            Clients.Others.Create(newData);
            

            return newData;
        }

        public void Delete(Data data)
        {
            Clients.Others.Delete(data);
        }

        public IEnumerable<Data> Get()
        {
            return data;
        }
    }
}