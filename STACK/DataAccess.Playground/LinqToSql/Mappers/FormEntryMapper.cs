using System.Collections.Generic;
using System.Linq;
using BO = BusinessObjects.Playground;

namespace DataAccess.Playground.LinqToSql.Mappers
{
    public class FormEntryMapper : IMapper<BO.FormEntry, FormEntry>
    {
        public BO.FormEntry ToBusinessObject(FormEntry entity)
        {
            if (entity == null) return null;

            return new BO.FormEntry
            {
                Id = entity.Id,
                FormId = entity.FormId,

                Content = entity.Content,

                CreatedBy = entity.CreatedBy,
                CreatedOn = entity.CreatedOn,
                User = entity.User,
                TS = entity.TS
            };
        }

        public IQueryable<BO.FormEntry> ToBusinessObjects(IEnumerable<FormEntry> entities)
        {
            return entities.Select(ToBusinessObject).AsQueryable();
        }

        public FormEntry ToEntity(BO.FormEntry data)
        {
            throw new System.NotImplementedException();
        }

        public FormEntry ToEntity(FormEntry entity, BO.FormEntry data)
        {
            throw new System.NotImplementedException();
        }
    }
}