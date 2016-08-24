using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Playground.Dapper
{
    public class BaseRepo
    {
        protected static IDbConnection OpenConnection()
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlaygroundLOCAL"].ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
