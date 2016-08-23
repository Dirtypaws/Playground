using System;
using System.Linq;
using BusinessObjects.Playground;
using DataAccess.Playground;
using DataAccess.Playground.LinqToSql.Repositories;
using NUnit.Framework;

namespace DataAccess.Integration.Playground
{
    [TestFixture]
    public class PlayerRepositoryTests
    {
        readonly IPlayerRepository _playerRepo;
        public PlayerRepositoryTests() : this(new PlayerRepository()) {}
        public PlayerRepositoryTests(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        [Test]
        public void Create_Test()
        {
            var entity = _playerRepo.Create(new Player
            {
                FirstName = "Great",
                LastName = "One",

                Handedness = 'L',

                JerseySizeID = 2,
                IsJerseyPaid = true,

                Number = 99,
                PracticeNumber = 99,
                PositionID = 2,
                SlackID = "Wayne Gretzky"

            });

            Assert.Greater(entity.ID, 0);
            Console.WriteLine("Inserted Wayne Gretzky");
        }

        [Test]
        public void Get_Test()
        {
            var data = _playerRepo.Get().ToList();
            Assert.IsFalse(data.Any(x => !x.Number.HasValue));

            Console.WriteLine($"Returned {data.Count} players");

            var lefties = _playerRepo.Get(x => x.Handedness == 'L').ToList();
            Assert.Greater(data.Count, lefties.Count);

            Console.WriteLine($"Returned {lefties.Count} left-handed players");
        }

        [Test]
        public void Update_Test()
        {
            var data = _playerRepo.Get().ToList();
            var entity = data.FirstOrDefault(x => x.ID == data.Max(y => y.ID));

            Console.WriteLine($"Retrieved: {entity.FullName} - #{entity.Number} - ID: {entity.ID}");

            var id = entity.ID;
            entity.FirstName = "Gordie";
            entity.LastName = "Howe";

            entity.Number = 9;
            entity.PracticeNumber = 9;

            var result = _playerRepo.Update(entity);
            Assert.AreEqual(entity.FullName, result.FullName, "FullName: Update did not properly occur");
            Assert.AreEqual(entity.Number, result.Number, "Number: Update did not properly occur");
            Assert.AreEqual(entity.PracticeNumber, result.PracticeNumber, "Number: Update did not properly occur");

            // Check for the cache refresh
            var cache = _playerRepo.Get(x => x.ID == id).FirstOrDefault();
            Assert.AreEqual(entity.FullName, cache.FullName, "FullName: Cached object was not refreshed");
            Assert.AreEqual(entity.Number, cache.Number, "Number: Cached object was not refreshed");
            Assert.AreEqual(entity.PracticeNumber, cache.PracticeNumber, "Number: Cached object was not refreshed");
        }
         
    }
}