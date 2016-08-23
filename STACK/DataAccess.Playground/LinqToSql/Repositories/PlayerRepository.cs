using System;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Playground.LinqToSql.Mappers;
using BO = BusinessObjects.Playground;
namespace DataAccess.Playground.LinqToSql.Repositories
{
    public class PlayerRepository : BaseRepository<BO.Player, Player>
    {
        public PlayerRepository() : base(new PlayerMapper()) { }
        public override Expression<Func<Player, bool>> cacheFilter { get { return x => x.Number.HasValue; } }

        public override void Delete(BO.Player data)
        {
            using (var db = PlaygroundFactory.CreateContext())
            {
                var entity = db.Players.FirstOrDefault(x => x.Id == data.ID);
                if (entity == null) return;

                entity.Number = null;
                db.Refresh(RefreshMode.KeepChanges, entity);

                db.SubmitChanges();

                RefreshCache(db);
            }
        }
    }
}