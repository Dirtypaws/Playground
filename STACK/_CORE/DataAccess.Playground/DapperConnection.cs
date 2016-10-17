using System.Data;
using System.Data.SqlClient;
using Dapper.FluentMap.Mapping;
using Framework.Helpers;
using Microsoft.Extensions.Configuration;

namespace DataAccess.EAM.Dapper
{
    public abstract class DapperConnection 
    {

        protected static IDbConnection OpenConnection()
        {
            var sql = new SqlConnection(ConfigurationHelper.Configuration.GetConnectionString("EAM"));
            sql.Open();
            return sql;
        }
    }
}