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
            Console.WriteLine($"Inserted {entity.FullName}");
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
            var max = data.FirstOrDefault(x => x.ID == data.Max(y => y.ID));

            Console.WriteLine($"Retrieved: {max.ProperName} - #{max.Number} - ID: {max.ID}");

            var id = max.ID;
            max.FirstName = "Gordie";
            max.LastName = "Howe";

            max.Number = 9;
            max.PracticeNumber = 9;

            var result = _playerRepo.Update(max);
            Assert.AreEqual(max.FullName, result.FullName, "FullName: Update did not properly occur");
            Assert.AreEqual(max.Number, result.Number, "Number: Update did not properly occur");
            Assert.AreEqual(max.PracticeNumber, result.PracticeNumber, "Number: Update did not properly occur");

            Console.WriteLine($"Updated {max.ID} to: {max.ProperName} - #{max.Number}");

            // Check for the cache refresh
            var cache = _playerRepo.Get(x => x.ID == id).FirstOrDefault();
            Assert.AreEqual(max.FullName, cache.FullName, "FullName: Cached object was not refreshed");
            Assert.AreEqual(max.Number, cache.Number, "Number: Cached object was not refreshed");
            Assert.AreEqual(max.PracticeNumber, cache.PracticeNumber, "Number: Cached object was not refreshed");

            Console.WriteLine($"Updated {max.ID}; Cache refreshed");
        }

        [Test]
        public void Delete_Test()
        {
            var data = _playerRepo.Get().ToList();
            var max = data.FirstOrDefault(x => x.ID == data.Max(y => y.ID));

            Console.WriteLine($"Retrieved: {max.FullName} - #{max.Number} - ID: {max.ID}");
            
            _playerRepo.Delete(max);

            var deleted = _playerRepo.Get(x => x.ID == max.ID);
            Assert.IsEmpty(deleted, "The record was not deleted from the cache.");

            Console.WriteLine($"Deleted {max.ID}; Cache refreshed");

        }

    }
}