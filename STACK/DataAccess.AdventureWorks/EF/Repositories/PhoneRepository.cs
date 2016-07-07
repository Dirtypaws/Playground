using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.AdventureWorks.EF.Mappers;
using DataAccess.AW;
using BO = BusinessObjects.Person;

namespace DataAccess.AdventureWorks.EF.Repositories
{
    public class PhoneRepository : CacheRepository<BO.Phone, PersonPhone>, IPhoneRepository
    {
        public BO.Phone Create(BO.Phone data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.Phone> Get(Expression<Func<BO.Phone, bool>> filter = null, Func<IQueryable<BO.Phone>, IOrderedQueryable<BO.Phone>> orderBy = null, bool useCache = true)
        {
            var data = Cache(PhoneMapper.ToBusinessObjects, null, useCache);

            if (filter != null) data = data.Where(filter);
            orderBy?.Invoke(data);

            return data;
        }

        public BO.Phone Update(BO.Phone data)
        {
            throw new NotImplementedException();
        }

        public void Delete(BO.Phone data)
        {
            throw new NotImplementedException();
        }
    }
}