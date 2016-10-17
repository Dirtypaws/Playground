using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework
{
    public class BaseAudit
    {
        [Column("Usr")]
        public string User { get; set; }
        public DateTime? TS { get; set; }
    }
}