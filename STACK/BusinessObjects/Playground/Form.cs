using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Playground
{
    [Table("Form")]
    public class Form
    {
        public int Id { get; set; }
        public int FormTypeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public string Schema { get; set; }
        public JSchema JSchema
        {
            get
            {
                var jschema = JSchema.Parse(Schema);
                return jschema;
            }
        }

        // Audit
        public bool? IsActive { get; set; }
        public string Version { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string User { get; set; }
        public DateTime? TS { get; set; }
    }
}
