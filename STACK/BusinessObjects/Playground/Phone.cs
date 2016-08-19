namespace BusinessObjects.Playground
{
    public class Phone
    {
        public int ID { get; set; }

        public int PlayerID { get; set; }
        public Player Player { get; set; }

        public int ContactTypeID { get; set; }
        public Lookup ContactType { get; set; }

        public string Number { get; set; }
    }
}