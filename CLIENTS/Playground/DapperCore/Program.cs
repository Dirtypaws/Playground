using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MySql.Data.MySqlClient;
using Dapper;

namespace DapperCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var _db = new MySqlConnection("server=localhost;userid=root;pwd=F00tball;port=3306;database=sakila;sslmode=none;");
            _db.Open();

            var result = _db.Query<Actor>("SELECT * FROM sakila.actor");

            Console.WriteLine(string.Join(Environment.NewLine, result.Select(a => $"{a.last_name}, {a.first_name}")));
            Console.ReadKey();
        }

        private class Actor
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
