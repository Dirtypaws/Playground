using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace MySql.EF
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            : base(options) { }


        public DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// Factory class for EmployeesContext
        /// </summary>
        public static class EmployeesContextFactory
        {
            public static EmployeesContext Create(string connectionString)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EmployeesContext>();
                optionsBuilder.UseMySQL(connectionString);

                //Ensure database creation
                var context = new EmployeesContext(optionsBuilder.Options);
                context.Database.EnsureCreated();

                return context;
            }
        }

        /// <summary>
        /// A basic class for an Employee
        /// </summary>
        public class Actor
        {
            public Actor() { }

            [Key]
            public int actor_id { get; set; }

            [MaxLength(30)]
            public string first_name { get; set; }

            [MaxLength(50)]
            public string last_name { get; set; }

            public DateTime last_update { get; set; }
        }
    }
}