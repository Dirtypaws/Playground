using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Kendo
{
    public class GridColumn
    {
        public string title { get; set; }
        public string field { get; set; }

        public string width { get; set; }
        public string template { get; set; }
        public string footerTemplate { get; set; }

        public bool locked { get; set; }
        public bool lockable { get; set; }

        public GridColumnAttr attributes { get; set; }
        public GridColumnSort sortable { get; set; }

        // C~tors
        public GridColumn() { }
        public GridColumn(string title)
        {
            this.title = title;
        }
        public GridColumn(string title, string field)
        {
            this.title = title;
            this.field = field;
        }

        // JSchema
        public GridColumn(KeyValuePair<string, JSchema> prop)
        {
            this.field = prop.Key;

            // this.title = prop.Value.Title
            this.title = string.IsNullOrEmpty(prop.Value.Title) ? this.field : prop.Value.Title;
            // this.template = prop.Value.Description;

            if (prop.Value.ExtensionData.ContainsKey("k-width"))
                this.width = prop.Value.ExtensionData["k-width"].ToString();
        }
    }

    public class GridColumnAttr
    {
        public string style { get; private set; }

        public GridColumnAttr(string style)
        {
            this.style = style;
        }
    }

    public class GridColumnSort
    {
        public string compare { get; private set; }

        public GridColumnSort(string compare)
        {
            this.compare = compare;
        }
    }

}
