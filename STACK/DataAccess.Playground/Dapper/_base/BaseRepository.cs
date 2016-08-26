using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Playground.Dapper
{
    public abstract class BaseRepository<T> : CacheRepository<T>, ICRUDRepository<T>
        where T : class
    {
        public virtual T Create(T data)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool useCache = true)
        {
            var data = Cache(useCache);

            if (filter != null) data = data.Where(filter);
            orderBy?.Invoke(data);

            return data;
        }

        public virtual T Update(T data)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T data)
        {
            throw new NotImplementedException();
        }
    }
}