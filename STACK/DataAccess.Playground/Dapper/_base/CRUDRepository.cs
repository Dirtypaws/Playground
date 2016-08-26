using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Playground.Dapper
{
    public abstract class CRUDRepository<T> : DapperConnection, ICRUDRepository<T>
        where T : class
    {
        public virtual T Create(T data)
        {

            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool useCache = true)
        {
            throw new NotImplementedException();
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