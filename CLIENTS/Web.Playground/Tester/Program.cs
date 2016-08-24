using DataAccess.Playground.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json.Schema;
using Framework.Kendo;
using Newtonsoft.Json;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new FormRepo();
            var forms = repo.GetAll();

            //foreach (var form in forms)
            //{
            //    Console.WriteLine(form.Name);
            //    foreach (var prop in form.JSchema.Properties)
            //        Console.WriteLine(prop.Key + ": " + prop.Value);
            //}

            //----------------------------------------------------------------

            string testSchema =
            @"{

                'type': 'object',
                'title': 'form',
    
                'properties': {
                    'name': {
                       'title': 'first name',   
                       'type':'string',
                       'description':'my name',
                       'minLength': 5,

                       'k-width': '50px'
                     },

                    'age': {
                       'type':'string',
                       'description':'my name',
                       'minimum':  30,

                       'k-width': '100px'
                     },

                    'roles': {
                      'type': 'array',
                      'minItems': 1,
                      'items': { 'type': 'string' },
                      'uniqueItems': true
                    }
                }
              }";

            var schema = JSchema.Parse(testSchema);

            var cols = new List<GridColumn>();
            foreach (var prop in schema.Properties)
                cols.Add(new GridColumn(prop));

            string json = JsonConvert.SerializeObject(cols, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine("\n---------------------\n");

            //----------------------------------------------------------------

            // Each form/schema defines a collection of GridColumn..
            foreach (var form in forms)
            {
                var cols2 = form.JSchema.Properties.Select(x => new GridColumn(x));
                string json2 = JsonConvert.SerializeObject(cols2, Formatting.Indented);

                Console.WriteLine(form.Name);
                Console.WriteLine(json2);
            }
            
        }
    }
}
