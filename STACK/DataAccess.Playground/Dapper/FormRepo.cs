using BusinessObjects.Playground;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace DataAccess.Playground.Dapper
{
    public class FormRepo : BaseRepo
    {
        /// <summary>
        /// https://github.com/StackExchange/dapper-dot-net/tree/master/Dapper.Contrib
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Form> GetAll()
        {
            using (IDbConnection cn = OpenConnection())
            {
                var forms = cn.GetAll<Form>();
                return forms;
            }
        }

        public IEnumerable<Form> GetAllRaw()
        {
            using (IDbConnection cn = OpenConnection())
            {
                string query = @" SELECT * FROM Form";
                var forms = cn.Query<Form>(query);
                return forms;
            }
        }
    }
}
