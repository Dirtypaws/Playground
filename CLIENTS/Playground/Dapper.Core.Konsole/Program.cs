using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreServices.Interfaces;
using CoreServices.Services;
using DataAccess.Playground;
using DataAccess.Playground.Dapper.Repositories;
using Framework.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Dapper.Core.Konsole
{
    public class Program
    {
        static Program()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true);

            ConfigurationHelper.Configuration = builder.Build();
        }

        static readonly IPlayerService _playerSvc = new PlayerService();
        static readonly IPlayerRepository _playerRepository = new PlayerRepository(); 

        public static void Main(string[] args)
        {
            var player1 = _playerRepository.Get(x => x.ID == 1);
            var player2 = _playerSvc.Get(x => x.ID == 3);

            Console.WriteLine("player 1 - from repo(no lookups)");
            Console.WriteLine(JsonConvert.SerializeObject(player1, Formatting.Indented));

            Console.WriteLine("player 2 - from svc(lookup resolved)");
            Console.WriteLine(JsonConvert.SerializeObject(player2, Formatting.Indented));

            Console.ReadKey();

        }
    }
}
