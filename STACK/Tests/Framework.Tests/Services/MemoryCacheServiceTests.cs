using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BusinessObjects.Playground;
using Framework.Services;
using NUnit.Framework;

namespace Framework.Tests.Services
{
    [TestFixture]
    public class MemoryCacheServiceTests
    {

        [Test]
        public void SetGetTest()
        {
            const string key = "setGetTest";
            var data = new[] { 99, 67, 88 };

            MemoryCacheService.Add(data, key);
            var result = MemoryCacheService.Get<int[]>(key);

            Assert.AreEqual(data.Length, result.Count());
        }

        [Test]
        public void ExistTest()
        {
            const string key = "existTest";

            var data = new [] {99, 67, 88};

            MemoryCacheService.Add(data, key);

            Assert.IsTrue(MemoryCacheService.Exists(key));
        }

        [Test]
        public void RemoveTest()
        {
            const string key = "removeTest";

            var data = new[] { 99, 67, 88 };

            MemoryCacheService.Add(data, key);
            Assert.IsTrue(MemoryCacheService.Exists(key));

            MemoryCacheService.Clear(key);
            Assert.IsFalse(MemoryCacheService.Exists(key));

            Assert.IsNull(MemoryCacheService.Get<int[]>(key));
        }

        [Test]
        public void TimoutTest()
        {
            const string key = "timeoutTest";

            var data = new[] { 99, 67, 88 };

            MemoryCacheService.Add(data, key, null, TimeSpan.FromSeconds(2));

            Thread.Sleep(3000);

            Assert.IsFalse(MemoryCacheService.Exists(key));

            Assert.IsNull(MemoryCacheService.Get<int[]>(key));
        }

        [Test]
        public void SlideTest()
        {
            const string key = "timeoutTest";

            var data = new[] { 99, 67, 88 };

            MemoryCacheService.Add(data, key, null, TimeSpan.FromSeconds(5));

            // The exists call resets the sliding scale
            Thread.Sleep(3000);
            Assert.IsTrue(MemoryCacheService.Exists(key));

            // Make sure the exist call reset the slider
            Thread.Sleep(3000);                             
            Assert.IsTrue(MemoryCacheService.Exists(key));

            // Ensure it still expires after the 2nd exists hit
            Thread.Sleep(6000);
            Assert.IsFalse(MemoryCacheService.Exists(key));

        }

        [Test]
        public void ExpirationTest()
        {
            const string key = "expirationTest";

            var data = new[] { 99, 67, 88 };

            MemoryCacheService.Add(data, key, DateTime.UtcNow.AddSeconds(3));

            Assert.IsTrue(MemoryCacheService.Exists(key));

            Thread.Sleep(4000);

            Assert.False(MemoryCacheService.Exists(key));

        }

        [Test]
        public void GetAllTest()
        {
            const string baseKey = "getAll-";
            var data = new[] {99, 67, 88};

            for (int i = 0; i < 10; i++)
                MemoryCacheService.Add(data, baseKey + i);

            var result = MemoryCacheService.GetAll();

            for (int i = 0; i < 10; i++)
                Assert.IsTrue(result.Contains(baseKey + i));
        }

        [Test]
        public void RemoveAllTest()
        {
            var allKeys = MemoryCacheService.GetAll();

            if (allKeys.Length < 4)
                GetAllTest();

            var batch = allKeys.Take(2);
            MemoryCacheService.Clear(batch.ToArray());
            Assert.AreEqual(MemoryCacheService.GetAll().Length, allKeys.Length - 2);

            MemoryCacheService.ClearAll();
            Assert.AreEqual(0, MemoryCacheService.GetAll().Length);
        }

        
    }
}