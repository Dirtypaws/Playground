using System;

namespace BusinessObjects.Person
{
    public class Person
    {
        public int ID { get; set; }

        public string PersonType { get; set; }
        public int NameStyle { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Suffix { get; set; }

        public int EmailPromotion { get; set; }

        // public string AdditionalContactInfo { get; set; }

        public string Demographics { get; set; }

        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int[] TerritoryIDs { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string ProperName => $"{LastName}, {FirstName}";

    }
}