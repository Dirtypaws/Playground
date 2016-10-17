using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreServices.Interfaces;
using DataAccess.Playground;
using DataAccess.Playground.Dapper.Repositories;
using Framework;
using Framework.Services;

namespace CoreServices.Services
{
    public class LookupService : ILookupService
    {
        readonly ILookupRepository _lookupRepo;

        public LookupService() : this(new LookupRepository()) {}
        public LookupService(ILookupRepository lookupRepo)
        {
            _lookupRepo = lookupRepo;
        }

        public Lookup Create<T>(T data) where T : Lookup
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lookup> Get<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool useCache = true) where T : Lookup
        {
            if (LookupCache.Exists<T>())
                return LookupCache.Get<T>();

            var data = _lookupRepo.Get<T>();
            return LookupCache.Set<T>(data);
        }

        public Lookup Update<T>(T data) where T : Lookup
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T data) where T : Lookup
        {
            throw new NotImplementedException();
        }
    }
}