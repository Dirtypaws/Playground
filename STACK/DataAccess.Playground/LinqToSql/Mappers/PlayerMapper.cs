using System.Collections.Generic;
using System.Linq;
using BO = BusinessObjects.Playground;

namespace DataAccess.Playground.LinqToSql.Mappers
{
    public class PlayerMapper : IMapper<BO.Player, Player>
    {
        public BO.Player ToBusinessObject(Player entity)
        {
            if (entity == null) return null;

            return new BO.Player
            {
                ID = entity.Id,

                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Handedness = entity.Handedness,
                IsJerseyPaid = entity.JerseyPaid,
                JerseySizeID = entity.JerseySizeId,
                PositionID = entity.PositionId,
                SlackID = entity.SlackId,
                Number = entity.Number,
                PracticeNumber = entity.PracticeNumber
            };
        }

        public IQueryable<BO.Player> ToBusinessObjects(IEnumerable<Player> entities)
        {
            return entities.Select(ToBusinessObject).AsQueryable();
        }

        public Player ToEntity(BO.Player data)
        {
            if (data == null) return null;

            return new Player
            {
                Id = data.ID,

                FirstName = data.FirstName,
                LastName = data.LastName,

                Number = data.Number,
                PracticeNumber = data.PracticeNumber,

                Handedness = data.Handedness,

                JerseySizeId = data.JerseySizeID,
                JerseyPaid = data.IsJerseyPaid,

                PositionId = data.PositionID,
                SlackId = data.SlackID
            };
        }

        public Player ToEntity(Player entity, BO.Player data)
        {
            entity.Id = data.ID;

            entity.FirstName = data.FirstName;
            entity.LastName = data.LastName;

            entity.Number = data.Number;
            entity.PracticeNumber = data.PracticeNumber;

            entity.Handedness = data.Handedness;

            entity.JerseySizeId = data.JerseySizeID;
            entity.JerseyPaid = data.IsJerseyPaid;

            entity.PositionId = data.PositionID;
            entity.SlackId = data.SlackID;

            return entity;
        }
    }
}