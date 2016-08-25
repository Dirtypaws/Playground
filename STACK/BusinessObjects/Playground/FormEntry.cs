using System;

namespace BusinessObjects.Playground
{
    public class FormEntry
    {
        public int Id { get; set; }

        public int FormId { get; set; }
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string User { get; set; }
        public DateTime? TS { get; set; }
    }
}