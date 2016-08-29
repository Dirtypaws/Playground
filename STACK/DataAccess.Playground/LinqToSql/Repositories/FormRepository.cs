using System;
using System.Linq.Expressions;
using DataAccess.Playground.LinqToSql.Mappers;
using BO = BusinessObjects.Playground;

namespace DataAccess.Playground.LinqToSql.Repositories
{
    public class FormRepository : BaseRepository<BO.Form, Form>, IFormRepository
    {
        public FormRepository() : base(new FormMapper()) {}
        public override Expression<Func<Form, bool>> cacheFilter => x => x.IsActive;
    }
}