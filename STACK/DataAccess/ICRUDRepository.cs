using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface ICRUDRepository<T>
    {
        T Create(T data);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool useCache = true);

        bool Update(T data);
        void Delete(T data);
    }
}