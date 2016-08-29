using System;
using System.Linq.Expressions;
using DataAccess.Playground.LinqToSql.Mappers;
using BO = BusinessObjects.Playground;


namespace DataAccess.Playground.LinqToSql.Repositories
{
    public class FormEntryRepository : BaseRepository<BO.FormEntry, FormEntry>, IFormEntryRepository
    {
        public FormEntryRepository() : base(new FormEntryMapper()) {}
        public override Expression<Func<FormEntry, bool>> cacheFilter => x => !string.IsNullOrEmpty(x.Content);
    }
}