using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MySql.EF;

namespace EF.MySql
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("SampleConnection");

            // Create an employee instance and save the entity to the database
            using (var context = EmployeesContext.EmployeesContextFactory.Create(connectionString))
            {
                var actor = context.Actors.FirstOrDefault();
                Console.WriteLine($"Retrieved actor with Id: {actor.actor_id}");
            }

            Console.ReadKey();
        }
    }
}
