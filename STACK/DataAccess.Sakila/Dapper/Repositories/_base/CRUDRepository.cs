using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using Dapper.FastCrud;
using DataAccess.Sakila.Dapper.Mappers;

namespace DataAccess.Sakila.Dapper.Repositories
{
    public abstract class CRUDRepository<T> : DapperConnection<T>, ICRUDRepository<T>
        where T : class
    {
        // ReSharper disable once InconsistentNaming - Avoiding collisions
        public static readonly Type _type = typeof(T);

        public virtual T Create(T data)
        {
            using (var db = OpenConnection())
            {
                db.Insert(data);
                return data;
            }
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool useCache = true)
        {
            using (var db = OpenConnection())
            {
                SqlMapper.SetTypeMap(
                    _type,
                    new ColumnAttributeTypeMapper<T>());

                var data = db.Query<T>($"SELECT * FROM {SchemaName}.{TableName.ToLower()}", filter).AsQueryable();

                if (filter != null)
                    data = data.Where(filter);
                orderBy?.Invoke(data);

                SqlMapper.SetTypeMap(_type, null);

                return data.ToList();
            }
        }

        public virtual bool Update(T data)
        {
            using (var db = OpenConnection())
                return db.Update(data);
        }

        public virtual void Delete(T data)
        {
            using (var db = OpenConnection())
                db.Delete(data);
        }
    }
}