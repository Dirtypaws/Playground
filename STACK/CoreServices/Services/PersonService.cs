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
        readonly IPhoneRepository _phoneRepo;

        public PersonService() : this(new PersonRepository(), new PhoneRepository()) {}

        public PersonService(IPersonRepository personRepo, IPhoneRepository phoneRepo)
        {
            _personRepo = personRepo;
            _phoneRepo = phoneRepo;
        }

        public Person Create(Person data)
        {
            return _personRepo.Create(data);
        }

        public IEnumerable<Person> Get(Expression<Func<Person, bool>> filter = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, bool useCache = true, bool includeChildEntities = false)
        {
            var data = _personRepo.Get().ToArray();
            var phones = _phoneRepo.Get().ToArray();
            foreach (var person in data)
                person.Phones = phones.Where(x => x.PersonID == person.ID).ToList();

            return data;
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