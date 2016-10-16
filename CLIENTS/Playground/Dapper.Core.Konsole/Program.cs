using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects.Playground;
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

        static readonly IPlayerService PlayerSvc = new PlayerService();
        static readonly IPlayerRepository PlayerRepo = new PlayerRepository(); 

        public static void Main(string[] args)
        {
            var player1 = PlayerRepo.Get(x => x.PlayerID == 1);
            var player2 = PlayerSvc.Get(x => x.PlayerID == 3);

            Console.WriteLine("player 1 - from repo(no lookups)");
            Console.WriteLine(JsonConvert.SerializeObject(player1, Formatting.Indented));

            Console.WriteLine("player 2 - from svc(lookup resolved)");
            Console.WriteLine(JsonConvert.SerializeObject(player2, Formatting.Indented));

            var newPlayer = PlayerRepo.Create(new Player
            {
                FirstName = "Test",
                LastName = "Player",
                Handedness = 'L',
                Number = 3,
                IsJerseyPaid = true,
                PositionID = 3,
                JerseySizeID = 4,
                PracticeNumber = 21

            });

            Console.WriteLine($"Created player {newPlayer.PlayerID}");

            var fetchPlayer = PlayerSvc.Get(x => x.PlayerID == newPlayer.PlayerID);
            Console.WriteLine(JsonConvert.SerializeObject(fetchPlayer, Formatting.Indented));

            Console.ReadKey();

        }
    }
}
