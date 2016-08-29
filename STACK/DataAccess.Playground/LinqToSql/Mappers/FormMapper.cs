using System.Collections.Generic;
using System.Linq;
using BO = BusinessObjects.Playground;

namespace DataAccess.Playground.LinqToSql.Mappers
{
    public class FormMapper : IMapper<BO.Form, Form>
    {
        public BO.Form ToBusinessObject(Form entity)
        {
            if (entity == null) return null;

            return new BO.Form
            {
                Id = entity.Id,
                
                FormTypeId = entity.eFormTypeId,

                Name = entity.Name,
                Code = entity.Code,
                Description = entity.Description,
                Schema = entity.Schema,
                
                IsActive = entity.IsActive,
                Version = entity.Version,

                CreatedBy = entity.CreatedBy,
                CreatedOn  = entity.CreatedOn,
                User = entity.User,
                TS = entity.TS
            };
        }

        public IQueryable<BO.Form> ToBusinessObjects(IEnumerable<Form> entities)
        {
            return entities.Select(ToBusinessObject).AsQueryable();
        }

        public Form ToEntity(BO.Form data)
        {
            throw new System.NotImplementedException();
        }

        public Form ToEntity(Form entity, BO.Form data)
        {
            throw new System.NotImplementedException();
        }
    }
}