using System;
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
                LastName = entity.LastName,
                //PhoneNums = entity.PersonPhones.Select(x => x.PhoneNumber).ToArray()
            };
        }

        public static IQueryable<BO.Person> ToBusinessObjects(IEnumerable<Person> entities)
        {
            return entities.Select(ToBusinessObject).AsQueryable();
        }

        public static Person ToEntity(BO.Person obj)
        {
            return new Person
            {
                BusinessEntityID = obj.ID,

                FirstName = obj.FirstName,
                LastName = obj.LastName,

                PersonType = "EM",
                NameStyle = false,
                EmailPromotion = 0,
                ModifiedDate = DateTime.Now,
                rowguid = Guid.NewGuid()
            };
        }
         
    }
}