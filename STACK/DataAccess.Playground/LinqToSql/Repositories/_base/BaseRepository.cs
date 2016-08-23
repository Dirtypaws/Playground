using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Playground.LinqToSql.Mappers;

namespace DataAccess.Playground.LinqToSql.Repositories
{
    public abstract class BaseRepository<TResult, T> : CacheRepository<TResult, T>, ICRUDRepository<TResult>
        where TResult : class
        where T : class
    {
        protected BaseRepository(IMapper<TResult, T> mapper)
        {
            Mapper = mapper;
        }

        public sealed override IMapper<TResult, T> Mapper { get; set; }

        public virtual TResult Create(TResult data)
        {
            using (var db = PlaygroundFactory.CreateContext())
            {
                var entity = Mapper.ToEntity(data);

                db.GetTable<T>().InsertOnSubmit(entity);
                db.SubmitChanges();

                RefreshCache(db);

                return Mapper.ToBusinessObject(entity);
            }
        }

        public virtual IEnumerable<TResult> Get(Expression<Func<TResult, bool>> filter = null,
            Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null, bool useCache = true)
        {
            var data = Cache(useCache);

            if (filter != null) data = data.Where(filter);
            orderBy?.Invoke(data);

            return data;
        }

        public virtual TResult Update(TResult data)
        {
            using (var db = PlaygroundFactory.CreateContext())
            {
                var entity = Mapper.ToEntity(data);

                db.GetTable<T>().Attach(entity);
                db.SubmitChanges();

                return Mapper.ToBusinessObject(entity);
            }
        }

        public virtual void Delete(TResult data)
        {
            using (var db = PlaygroundFactory.CreateContext())
            {
                var entity = Mapper.ToEntity(data);

                db.GetTable<T>().DeleteOnSubmit(entity);
                db.SubmitChanges();

                RefreshCache(db);
            }
        }
    }
}