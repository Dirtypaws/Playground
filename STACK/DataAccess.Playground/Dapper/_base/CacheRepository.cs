using System;
using System.Data;
using System.Linq;
using Dapper;
using Framework.Services;
using TableAttribute = System.ComponentModel.DataAnnotations.Schema.TableAttribute;

namespace DataAccess.Playground.Dapper
{
    public abstract class CacheRepository<T> : DapperConnection
        where T : class
    {
        public abstract string cacheFilter { get; }

        protected IQueryable<T> Cache(bool useCache = true)
        {
            string key = typeof(T).Name;

            var data = MemoryCacheService.Get<IQueryable<T>>(key);
            if (!useCache) data = null;

            if (data != null) return data;

            using (var db = OpenConnection())
            {
                
                var attr = typeof (T).GetCustomAttributes(typeof (TableAttribute), false).FirstOrDefault();
                
                string tableName = (attr as TableAttribute)?.Name;

                // If they didn't supply the table attribute - we'll use the class name and hope for the best.
                if (string.IsNullOrEmpty(tableName)) tableName = key;
                string filter = cacheFilter;
                if (string.IsNullOrEmpty(filter)) filter = "1=1";


                data = db.Query<T>($"SELECT * FROM {tableName} WHERE {filter}").AsQueryable();

            }

            MemoryCacheService.Add(data, key, DateTimeOffset.Now.AddHours(12));

            return data;
        }

        protected void RefreshCache(IDbConnection db)
        {
            string key = typeof(T).Name;
            MemoryCacheService.Clear(key);

            var attr = typeof(T).GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault();
            string tableName = (attr as TableAttribute)?.Name;

            // If they didn't supply the table attribute - we'll use the class name and hope for the best.
            if (string.IsNullOrEmpty(tableName)) tableName = key;
            string filter = cacheFilter;
            if (string.IsNullOrEmpty(filter)) filter = "1=1";

            var data = db.Query<T>($"SELECT * FROM {tableName} WHERE {filter}").AsQueryable();

            MemoryCacheService.Add(data, key, DateTimeOffset.Now.AddHours(12));
        }
    }
}