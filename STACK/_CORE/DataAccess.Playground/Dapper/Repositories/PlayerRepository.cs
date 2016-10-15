using System.ComponentModel.DataAnnotations.Schema;
using BusinessObjects.Playground;
using Dapper.FastCrud;

namespace DataAccess.Playground.Dapper.Repositories
{
    public class PlayerRepository : CRUDRepository<Player>, IPlayerRepository
    {
        public override string TableName => "Player";
        public override string SchemaName => "roster";

        static PlayerRepository()
        {
            OrmConfiguration.GetDefaultEntityMapping<Player>()
                .SetProperty(e => e.ID,
                    d => d.SetDatabaseGenerated(DatabaseGeneratedOption.Identity)
                        .SetPrimaryKey()
                        .SetDatabaseColumnName("Id"));
        }
    }
}