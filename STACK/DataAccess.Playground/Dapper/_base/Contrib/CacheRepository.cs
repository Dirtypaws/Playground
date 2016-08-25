using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Dapper.Contrib.Extensions;
using Framework.Services;

namespace DataAccess.Playground.Dapper.Contrib
{
    public abstract class CacheRepository<T> : DapperConnection
        where T : class
    {
        public abstract Expression<Func<T, bool>> cacheFilter { get; }

        protected IQueryable<T> Cache(bool useCache = true)
        {
            string key = typeof(T).Name;

            var data = MemoryCacheService.Get<IQueryable<T>>(key);
            if (!useCache) data = null;

            if (data != null) return data;

            using (var db = OpenConnection())
            {
                data = db.GetAll<T>().AsQueryable();
                if (cacheFilter != null) data = data.Where(cacheFilter);
            }

            MemoryCacheService.Add(data, key, DateTimeOffset.Now.AddHours(12));

            return data;
        }

        protected void RefreshCache(IDbConnection db)
        {
            string key = typeof(T).Name;
            MemoryCacheService.Clear(key);

            var data = db.GetAll<T>().AsQueryable();
            if (cacheFilter != null) data = data.Where(cacheFilter);

            MemoryCacheService.Add(data, key, DateTimeOffset.Now.AddHours(12));
        }
    }
}