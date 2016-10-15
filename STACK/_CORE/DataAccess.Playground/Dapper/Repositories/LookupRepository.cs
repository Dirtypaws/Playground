using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using Dapper.FastCrud;
using Framework;

namespace DataAccess.Playground.Dapper.Repositories
{
    public class LookupRepository : DapperConnection, ILookupRepository
    {
        void ConfigureLookup<T>() where T : Lookup
        {
            OrmConfiguration.GetDefaultEntityMapping<T>()
                .SetSchemaName("dbo")
                .SetTableName(typeof(T).Name)
                .SetProperty(e => e.ID,
                    p => p.SetDatabaseColumnName("Id")
                        .SetDatabaseGenerated(DatabaseGeneratedOption.Identity)
                        .SetPrimaryKey());

        }

        public T Create<T>(T data) where T : Lookup
        {
            ConfigureLookup<T>();

            using (var db = OpenConnection())
            {
                db.Insert(data);
                return data;
            }
        }

        public IEnumerable<T> Get<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool useCache = true) 
            where T : Lookup
        {
            ConfigureLookup<T>();

            using (var db = OpenConnection())
            {
                var data = db.Query<T>($"SELECT * FROM dbo.{typeof(T).Name}", filter).AsQueryable();
                orderBy?.Invoke(data);

                return data;
            }
        }

        public T Update<T>(T data) where T : Lookup
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T data) where T : Lookup
        {
            throw new NotImplementedException();
        }
    }
}