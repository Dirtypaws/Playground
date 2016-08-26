using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Playground.Dapper
{
    public abstract class DapperConnection
    {
        protected static IDbConnection OpenConnection()
        {
            var sql = new SqlConnection(ConfigurationManager.ConnectionStrings[$"Playground{ConfigurationManager.AppSettings.Get("Environment")}"].ConnectionString);
            sql.Open();
            return sql;
        }

    }
}