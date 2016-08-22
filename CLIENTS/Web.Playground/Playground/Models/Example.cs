using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Playground.Models
{
    public class Example
    {
        public string Group { get; set; } 

        public IEnumerable<string> IconClasses { get; set; }
        public bool IsIconStack => IconClasses.Count() > 1;

        public string Title { get; set; }
        public string Route { get; set; }
        public string Description { get; set; }
    }
}