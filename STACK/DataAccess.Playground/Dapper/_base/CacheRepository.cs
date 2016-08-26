using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Dapper;
using Framework.Services;

namespace DataAccess.Playground.Dapper
{
    public abstract class CacheRepository<T> : DapperConnection
        where T : class
    {
        public abstract string cacheFilter { get; }

        private readonly string key = nameof(T);
        
        protected IQueryable<T> Cache(bool useCache = true)
        {
            var data = MemoryCacheService.Get<IQueryable<T>>(key);
            if (!useCache) data = null;

            if (data != null) return data;

            using (var db = OpenConnection())
            {
                var table = key;
                var tableAttribute =
                    typeof (T).GetCustomAttributes(typeof (TableAttribute), false).FirstOrDefault() as TableAttribute;
                if (tableAttribute != null)
                    table = tableAttribute.Name;

                var filter = "1=1";
                if (!string.IsNullOrEmpty(cacheFilter))
                    filter = cacheFilter;

                var map = new CustomPropertyTypeMap(typeof(T),
                    (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetDescriptionFromAttribute(prop) == columnName));
                SqlMapper.SetTypeMap(typeof(T), map);

                data = db.Query<T>($"SELECT * FROM {table} WHERE {filter}").AsQueryable();

                SqlMapper.SetTypeMap(typeof(T), null);
            }

            MemoryCacheService.Add(data, key, DateTimeOffset.Now.AddHours(12));

            return data;
        }

        protected void RefreshCache(IDbConnection db)
        {
            MemoryCacheService.Clear(key);

            var schema = "[dbo]";
            var table = key;
            var tableAttribute =
                typeof(T).GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() as TableAttribute;
            if (tableAttribute != null)
            {
                table = tableAttribute.Name;
                schema = tableAttribute.Schema;
            }

            var filter = "1=1";
            if (!string.IsNullOrEmpty(cacheFilter))
                filter = cacheFilter;

            var data = db.Query<T>($"SELECT * FROM {schema}.{table} WHERE {filter}").AsQueryable();

            MemoryCacheService.Add(data, key, DateTimeOffset.Now.AddHours(12));
        }

        static string GetDescriptionFromAttribute(MemberInfo member)
        {
            if (member == null) return null;
            var attrib = (ColumnAttribute)Attribute.GetCustomAttribute(member, typeof(ColumnAttribute), true);
            return attrib != null ? attrib.Name : member.Name;
        }
    }
}