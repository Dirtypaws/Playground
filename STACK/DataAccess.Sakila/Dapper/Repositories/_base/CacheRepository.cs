using System.Data;
using System.Linq;

namespace DataAccess.Sakila.Dapper.Repositories
{
    public abstract class CacheRepository<T> : DapperConnection<T>
        where T : class
    {
        public abstract string CacheFilter { get; }

        readonly string _key = typeof(T).Name;

        protected IQueryable<T> Cache(bool useCache = true)
        {
            return null;
        }

        protected void RefreshCache(IDbConnection db)
        {
            
        }
    }
}