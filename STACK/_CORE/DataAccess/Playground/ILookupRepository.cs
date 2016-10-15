using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework;

namespace DataAccess.Playground
{
    public interface ILookupRepository
    {
        T Create<T>(T data) where T : Lookup;

        IEnumerable<T> Get<T>(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool useCache = true) where T : Lookup;

        T Update<T>(T data) where T : Lookup;
        void Delete<T>(T data) where T : Lookup;
    }
}