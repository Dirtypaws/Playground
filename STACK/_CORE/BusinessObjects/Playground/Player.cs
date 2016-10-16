using System.ComponentModel.DataAnnotations.Schema;
using BusinessObjects.Playground.Lookups;
using Framework;

namespace BusinessObjects.Playground
{
    public class Player : Person
    {     
        public int? Number { get; set; }
        public int? PracticeNumber { get; set; }

        public int? JerseySizeID { get; set; }
        // public JerseySize JerseySize { get; set; }
        [Column("JerseyPaid")]
        public bool IsJerseyPaid { get; set; }

        public char? Handedness { get; set; }

        public int? PositionID { get; set; }
        public Lookup Position { get; set; }
    }
}