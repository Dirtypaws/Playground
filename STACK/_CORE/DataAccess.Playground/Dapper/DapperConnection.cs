using System.Data;
using System.Data.SqlClient;
using Dapper.FastCrud;
using Framework.Helpers;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Playground.Dapper
{
    public abstract class DapperConnection<T> : DapperConnection
    {
        public virtual string TableName => typeof(T).Name;
        public virtual string SchemaName => "dbo";

        protected DapperConnection()
        {
            OrmConfiguration.GetDefaultEntityMapping<T>()
                .SetSchemaName(SchemaName)
                .SetTableName(TableName);
        }
    }

    public abstract class DapperConnection
    {
        protected static IDbConnection OpenConnection()
        {
            var sql = new SqlConnection(ConfigurationHelper.Configuration.GetConnectionString("Playground"));
            sql.Open();
            return sql;
        }

    }
}