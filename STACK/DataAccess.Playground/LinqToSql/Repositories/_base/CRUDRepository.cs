using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Playground.LinqToSql.Mappers;

namespace DataAccess.Playground.LinqToSql.Repositories
{
    public abstract class CRUDRepository<TResult, T> : ICRUDRepository<TResult>
        where TResult : class
        where T : class
    {
        private IMapper<TResult, T> Mapper { get; }

        protected CRUDRepository(IMapper<TResult, T> mapper)
        {
            Mapper = mapper;
        }

        public virtual TResult Create(TResult data)
        {
            using (var db = PlaygroundFactory.CreateContext())
            {
                var entity = Mapper.ToEntity(data);

                db.GetTable<T>().InsertOnSubmit(entity);
                db.SubmitChanges();

                return Mapper.ToBusinessObject(entity);
            }
        }

        public virtual IEnumerable<TResult> Get(Expression<Func<TResult, bool>> filter = null, Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null, bool useCache = true)
        {
            using (var db = PlaygroundFactory.CreateContext())
            {
                var data = db.GetTable<T>().Select(Mapper.ToBusinessObject).AsQueryable();

                if (filter != null) data = data.Where(filter);
                orderBy?.Invoke(data);

                return data.ToList();
            }
        }

        public virtual TResult Update(TResult data)
        {
            using (var db = PlaygroundFactory.CreateContext())
            {
                var entity = Mapper.ToEntity(data);

                var table = db.GetTable<T>();
                table.Attach(entity);
                db.Refresh(RefreshMode.KeepCurrentValues, entity);

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
            }
        }
    }
}