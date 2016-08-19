using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Playground.LinqToSql.Mappers;
using Framework.Services;

namespace DataAccess.Playground.LinqToSql.Repositories
{
    public abstract class CacheRepository<TResult, T>
        where TResult : class
        where T : class
    {
        public abstract IMapper<TResult, T> Mapper { get; set; }
        public abstract Expression<Func<T, bool>> cacheFilter { get; }
        private Func<IEnumerable<T>, IQueryable<TResult>> cacheMapper => Mapper.ToBusinessObjects;

        protected IQueryable<TResult> Cache(bool useCache = true)
        {
            const string key = nameof(TResult);

            var data = MemoryCacheService.Get<IQueryable<TResult>>(key);
            if (!useCache) data = null;

            if (data != null) return data;

            using (var db = PlaygroundFactory.CreateContext())
            {
                var query = db.GetTable<T>().AsQueryable();
                if (cacheFilter != null) query = query.Where(cacheFilter);
                data = cacheMapper(query.ToList());
            }

            MemoryCacheService.Add(data, key, DateTimeOffset.Now.AddHours(12));

            return data.AsQueryable();
        }

        protected void RefreshCache(DataContext db)
        {
            const string key = nameof(T);
            MemoryCacheService.Clear(key);

            var query = db.GetTable<T>().AsQueryable();
            if (cacheFilter != null) query = query.Where(cacheFilter);
            var data = cacheMapper(query.ToList());

            MemoryCacheService.Add(data, key, DateTimeOffset.Now.AddHours(12));
        }
    }
}