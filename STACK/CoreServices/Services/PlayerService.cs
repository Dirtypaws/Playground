using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessObjects.Playground;
using BusinessObjects.Playground.Lookups;
using CoreServices.Interfaces;
using DataAccess.Playground;
using DataAccess.Playground.Dapper.Repositories;

namespace CoreServices.Services
{
    public class PlayerService : IPlayerService
    {
        readonly IPlayerRepository _playerRepo;
        readonly ILookupService _lookupSvc;

        public PlayerService() : this(new PlayerRepository(), new LookupService()) { }

        public PlayerService(IPlayerRepository playerRepo, ILookupService lookupSvc)
        {
            _playerRepo = playerRepo;
            _lookupSvc = lookupSvc;
        }

        public Player Create(Player data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> Get(Expression<Func<Player, bool>> filter = null, Func<IQueryable<Player>, IOrderedQueryable<Player>> orderBy = null, bool useCache = true, bool includeChildEntities = false)
        {
            var data = _playerRepo.Get(filter, orderBy, useCache);
            var positions = _lookupSvc.Get<Position>().ToArray();

            foreach (var player in data)
            {
                player.Position = positions.FirstOrDefault(x => x.ID == player.PositionID);
            }

            return data;
        }

        public Player Update(Player data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Player data)
        {
            throw new NotImplementedException();
        }
    }
}