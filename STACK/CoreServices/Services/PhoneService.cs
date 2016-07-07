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
    public class PhoneService : IPhoneService
    {
        readonly IPersonRepository _personRepo;
        readonly IPhoneRepository _phoneRepo;

        public PhoneService() : this(new PersonRepository(), new PhoneRepository()) {}

        public PhoneService(IPersonRepository personRepo, IPhoneRepository phoneRepo)
        {
            _personRepo = personRepo;
            _phoneRepo = phoneRepo;
        }

        public Phone Create(Phone data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phone> Get(Expression<Func<Phone, bool>> filter = null, Func<IQueryable<Phone>, IOrderedQueryable<Phone>> orderBy = null, bool useCache = true, bool includeChildEntities = false)
        {
            var phones = _phoneRepo.Get();
            return phones;
        }

        public Phone Update(Phone data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Phone data)
        {
            throw new NotImplementedException();
        }
    }
}