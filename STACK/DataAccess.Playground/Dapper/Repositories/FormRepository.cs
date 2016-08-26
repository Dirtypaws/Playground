using System;
using System.Linq.Expressions;
using BusinessObjects.Playground;

namespace DataAccess.Playground.Dapper.Repositories
{
    public class FormRepository : BaseRepository<Form>, IFormRepository
    {
        public override string cacheFilter => "IsActive = 1";
    }
}