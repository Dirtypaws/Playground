using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Playground.LinqToSql.Mappers
{
    public interface IMapper<TResult, T>
    {
        TResult ToBusinessObject(T entity);
        IQueryable<TResult> ToBusinessObjects(IEnumerable<T> entities);

        T ToEntity(TResult data);
        T ToEntity(T entity, TResult data);
    }
}