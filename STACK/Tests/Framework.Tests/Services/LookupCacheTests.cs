using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Services;
using NUnit.Framework;

namespace Framework.Tests.Services
{
    [TestFixture]
    public class LookupCacheTests
    {
        readonly List<SimpleLookup> _simple = new List<SimpleLookup>
            {
                new SimpleLookup {ID = 1, Key = "Blue", Name = "$E[30;104m", TS = DateTime.UtcNow, User = "system"},
                new SimpleLookup {ID = 2, Key = "Red", Name = "$E[90;101m", TS = DateTime.UtcNow, User = "system"},
                new SimpleLookup {ID = 3, Key = "Yellow", Name = " $E[93;103m", TS = DateTime.UtcNow, User = "system"}
            };

        readonly List<ComplexLookup> _complex = new List<ComplexLookup>
            {
                new ComplexLookup {ID = 1, Key = "Blue", Name = "$E[30;104m", Description = "ABC", TS = DateTime.UtcNow, User = "system"},
                new ComplexLookup {ID = 2, Key = "Red", Name = "$E[90;101m", Description = "DEF", TS = DateTime.UtcNow, User = "system"},
                new ComplexLookup {ID = 3, Key = "Yellow", Name = " $E[93;103m", Description = "GHI", TS = DateTime.UtcNow, User = "system"}
            };

        [Test]
        public void SetGetTest()
        {


            LookupCache.Set<SimpleLookup>(_simple);

            var result = LookupCache.Get<SimpleLookup>();

            Assert.AreEqual(_simple.Count, result.Length);

            Assert.DoesNotThrow(() => LookupCache.Set<SimpleLookup>(_simple));
        }

        [TestCase(1, "Blue")]
        [TestCase(2, "Red")]
        [TestCase(3, "Yellow")]
        [TestCase(4, null)]
        public void GetWithPredicateTest(int id, string exp)
        {
            LookupCache.Set<SimpleLookup>(_simple);

            var result = LookupCache.Get<SimpleLookup>(x => x.ID == id);

            Assert.IsTrue(exp == result.FirstOrDefault()?.Key);
        }

        [Test]
        public void ExistTest()
        {
            LookupCache.Set<SimpleLookup>(_simple);

            Assert.IsTrue(LookupCache.Exists<SimpleLookup>());
        }

        [Test]
        public void ClearTest()
        {
            LookupCache.Set<SimpleLookup>(_simple);

            Assert.IsTrue(LookupCache.Exists<SimpleLookup>());

            LookupCache.Clear<SimpleLookup>();

            Assert.IsFalse(LookupCache.Exists<SimpleLookup>());
        }

        [Test]
        public void ClearAllTest()
        {
            LookupCache.Set<SimpleLookup>(_simple);
            LookupCache.Set<ComplexLookup>(_complex);

            Assert.IsTrue(LookupCache.Exists<SimpleLookup>());
            Assert.IsTrue(LookupCache.Exists<ComplexLookup>());

            LookupCache.Clear();

            Assert.IsFalse(LookupCache.Exists<SimpleLookup>());
            Assert.IsFalse(LookupCache.Exists<ComplexLookup>());
        }

        public class SimpleLookup : Lookup
        {
            
        }

        public class ComplexLookup : Lookup
        {
            public string Description { get; set; }
        }
        
    }
}