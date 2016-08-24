using System.Collections.Generic;
using System.Linq;
using BO = BusinessObjects.Person;

namespace DataAccess.AdventureWorks.EF.Mappers
{
    public class PhoneMapper
    {
        public static BO.Phone ToBusinessObject(PersonPhone entity)
        {
            if (entity == null) return null;

            return new BO.Phone
            {
                PersonID = entity.BusinessEntityID,

                PhoneNumber = entity.PhoneNumber,
                PhoneNumberTypeID = entity.PhoneNumberTypeID,

                ModifiedDate = entity.ModifiedDate
            };
        }

        public static IQueryable<BO.Phone> ToBusinessObjects(IEnumerable<PersonPhone> entities)
        {
            return entities.Select(ToBusinessObject).AsQueryable();
        }
         
    }
}