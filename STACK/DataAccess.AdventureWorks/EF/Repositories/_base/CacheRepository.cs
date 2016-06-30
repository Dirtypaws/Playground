using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Framework.Services;

namespace DataAccess.AdventureWorks.EF.Repositories
{
    public abstract class CacheRepository<TResult, T>
        where TResult : class
        where T : class
    {
        public IQueryable<TResult> Cache(Func<IEnumerable<T>, IQueryable<TResult>> mapper,
            Expression<Func<T, bool>> filter = null, bool useCache = true)
        {
            const string key = nameof(TResult);

            var data = MemoryCacheService.Get<IQueryable<TResult>>(key);
            if (!useCache) data = null;

            if (data != null) return data;

            using (var db = new Data())
            {
                var context = ((IObjectContextAdapter) db).ObjectContext;
                var query = context.CreateObjectSet<T>().AsQueryable();
                if (filter != null) query = query.Where(filter);
                data = mapper(query.ToList());
            }

            MemoryCacheService.Add(data, key, DateTimeOffset.Now.AddHours(12));

            return data.AsQueryable();
        }
    }
}