using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework
{
    public class BaseUpdate
    {
        [Column("last_update")]
        public DateTime LastUpdate { get; set; }
    }
}