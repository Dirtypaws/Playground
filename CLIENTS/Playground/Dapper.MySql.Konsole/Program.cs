using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects.Sakila;
using DataAccess.Sakila;
using DataAccess.Sakila.Dapper.Repositories;
using Framework.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Dapper.MySql.Konsole
{
    public class Program
    {
        static Program()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true);

            ConfigurationHelper.Configuration = builder.Build();
        }

        static IActorRepository actorRepo = new ActorRepository();

        public static void Main(string[] args)
        {

            var data = actorRepo.Get(x => x.Id == 31);
            Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));

            var newActor = new Actor
            {
                FirstName = "Matt",
                LastName = "Krizanac",
                LastUpdate = DateTime.UtcNow
            };

            var result = actorRepo.Create(newActor);

            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));

            Console.ReadKey();
        }
    }
}
