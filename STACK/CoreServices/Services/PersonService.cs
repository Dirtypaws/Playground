using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessObjects.Person;
using CoreServices.Interfaces;
using DataAccess.AdventureWorks.EF.Repositories;
using DataAccess.AW;

namespace CoreServices.Services
{
    public class PersonService : IPersonService
    {
        readonly IPersonRepository _personRepo;

        public PersonService() : this(new PersonRepository()) {}

        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public Person Create(Person data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Get(Expression<Func<Person, bool>> filter = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, bool useCache = true, bool includeChildEntities = false)
        {
            return _personRepo.Get();
        }

        public Person Update(Person data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person data)
        {
            throw new NotImplementedException();
        }
    }
}