using BusinessObjects.Playground;

namespace DataAccess.Playground.Dapper.Repositories
{
    public class FormEntryRepository : BaseRepository<FormEntry>, IFormEntryRepository
    {
        public override string cacheFilter => "IsActive = 1";
    }
}