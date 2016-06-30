using System.Collections.Generic;
using System.Linq;
using BO = BusinessObjects.Person;

namespace DataAccess.AdventureWorks.EF.Mappers
{
    public class PersonMapper
    {
        public static BO.Person ToBusinessObject(Person entity)
        {
            if (entity == null) return null;

            return new BO.Person
            {
                ID = entity.BusinessEntityID,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }

        public static IQueryable<BO.Person> ToBusinessObjects(IEnumerable<Person> entities)
        {
            return entities.Select(ToBusinessObject).AsQueryable();
        }
         
    }
}