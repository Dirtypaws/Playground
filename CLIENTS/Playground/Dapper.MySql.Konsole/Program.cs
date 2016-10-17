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

            var actor = new Actor
            {
                FirstName = "Matt",
                LastName = "Krizanac",
                LastUpdate = DateTime.UtcNow
            };

            var newActor = actorRepo.Create(actor);

            Console.WriteLine(JsonConvert.SerializeObject(newActor, Formatting.Indented));

            actor.FirstName = "Matthew";

            Actor updateActor = null;
            if (actorRepo.Update(actor))
                updateActor = actorRepo.Get(x => x.Id == actor.Id).FirstOrDefault();

            if (updateActor != null)
                Console.WriteLine(JsonConvert.SerializeObject(updateActor, Formatting.Indented));

            actorRepo.Delete(actor);
            var deleteActor = actorRepo.Get(x => x.Id == actor.Id).FirstOrDefault();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(deleteActor == null ? "Actor deleted" : "***Actor NOT deleted***");

            Console.ReadKey();
        }
    }
}
