using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessObjects.Playground.Lookups;
using Framework;

namespace CoreServices.Interfaces
{
    public interface ILookupService
    {
        Lookup Create<T>(T data) where T : Lookup;

        IEnumerable<Lookup> Get<T>(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool useCache = true) where T : Lookup;

        Lookup Update<T>(T data) where T : Lookup;
        void Delete<T>(T data) where T : Lookup;
    }
}