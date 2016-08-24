using System;

namespace BusinessObjects.Person
{
    public class Phone
    {
        public int PersonID { get; set; }
        public Person Person { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}