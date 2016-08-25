using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Playground.Dapper
{
    public abstract class DapperConnection
    {
        private static SqlConnection cnx;
        private static SqlConnection sql
        {
            get
            {
                if (cnx == null)
                {
                    var env = ConfigurationManager.AppSettings.Get("Environment");
                    cnx = new SqlConnection(ConfigurationManager.ConnectionStrings[$"Playground{env}"].ConnectionString);
                }

                return cnx;

            }
        }

        protected static IDbConnection OpenConnection()
        {
            sql.Open();
            return sql;
        }

    }
}