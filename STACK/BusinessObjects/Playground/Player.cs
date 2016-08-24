namespace BusinessObjects.Playground
{
    public class Player
    {
        public int ID { get; set; }

        public string SlackID { get; set; }
        
        public int? Number { get; set; }
        public int? PracticeNumber { get; set; }

        public int? JerseySizeID { get; set; }
        // public JerseySize JerseySize { get; set; }
        public bool IsJerseyPaid { get; set; }

        public char? Handedness { get; set; }

        public int? PositionID { get; set; }
        // public Position Position { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string ProperName => $"{LastName}, {FirstName}";
    }
}