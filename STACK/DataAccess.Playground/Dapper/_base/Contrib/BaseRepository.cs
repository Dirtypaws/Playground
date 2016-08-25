using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Dapper.Contrib.Extensions;

namespace DataAccess.Playground.Dapper.Contrib
{
    public abstract class BaseRepository<T> : CacheRepository<T>, ICRUDRepository<T>
        where T : class
    {
        public virtual T Create(T data)
        {
            using (var db = OpenConnection())
            {
                long id = db.Insert(data);
                RefreshCache(db);

                return data;
            }
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
            using (var db = OpenConnection())
            {
                bool success = db.Update(data);
                if(success)
                    RefreshCache(db);
                else
                    throw new DataException($"Unable to update record");

                return data;
            }
        }

        public virtual void Delete(T data)
        {
            using (var db = OpenConnection())
            {
                bool success = db.Delete(data);
                if (success)
                    RefreshCache(db);
            }
        }
    }
}