namespace BusinessObjects.Playground
{
    public class Person
    {
        public int ID { get; set; }

        public string SlackID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string ProperName => $"{LastName}, {FirstName}";
    }
}