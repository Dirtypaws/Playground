using System.Linq;
using DataAccess.Playground;
using DataAccess.Playground.Dapper.Repositories;
using NUnit.Framework;

namespace DataAccess.Integration.Playground
{
    [TestFixture]
    public class FormRepositoryTests
    {
        readonly IFormRepository _formRepo;
        public FormRepositoryTests() : this(new FormRepository()) { }
        public FormRepositoryTests(IFormRepository formRepo)
        {
            _formRepo = formRepo;
        }

        [Test]
        public void Get_Test()
        {
            var data = _formRepo.Get(x => x.Id == 1);
            Assert.AreEqual(1, data.Count());
        }
         
    }
}