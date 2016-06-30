using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.AdventureWorks.EF.Mappers;
using DataAccess.AW;
using BO = BusinessObjects.Person;

namespace DataAccess.AdventureWorks.EF.Repositories
{
    public class PersonRepository : CacheRepository<BO.Person, Person>, IPersonRepository
    {
        public BO.Person Create(BO.Person data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.Person> Get(Expression<Func<BO.Person, bool>> filter = null, Func<IQueryable<BO.Person>, IOrderedQueryable<BO.Person>> orderBy = null, bool useCache = true, bool includeChildEntities = false)
        {
            var data = Cache(PersonMapper.ToBusinessObjects);

            if (filter != null) data = data.Where(filter);
            orderBy?.Invoke(data);

            return data;

        }

        public BO.Person Update(BO.Person data)
        {
            throw new NotImplementedException();
        }

        public void Delete(BO.Person data)
        {
            throw new NotImplementedException();
        }
    }
}