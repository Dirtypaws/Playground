using DataAccess.Playground.Dapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Integration.Playground
{
    [TestFixture]
    public class FormTests
    {
        [Test]
        public void GetAll_Test()
        {
            var repo = new FormRepo();
            var forms = repo.GetAll();
            Assert.IsNotEmpty(forms);
        }
    }
}
