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
            using (var db = new Data())
            {
                var be = new BusinessEntity { ModifiedDate = DateTime.Now, rowguid = Guid.NewGuid() };
                db.BusinessEntities.Add(be);
                db.SaveChanges();

                data.ID = be.BusinessEntityID;

                var entity = PersonMapper.ToEntity(data);
                db.People.Add(entity);
                db.SaveChanges();

                ClearCache();
                Get();

                return PersonMapper.ToBusinessObject(entity);
            }
        }

        public IEnumerable<BO.Person> Get(Expression<Func<BO.Person, bool>> filter = null, Func<IQueryable<BO.Person>, IOrderedQueryable<BO.Person>> orderBy = null, bool useCache = true)
        {
            var data = Cache(PersonMapper.ToBusinessObjects, null, useCache);

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