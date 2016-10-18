using System.Configuration;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Dapper.FastCrud;
using MySql.Data.MySqlClient;

namespace DataAccess.Playground.Dapper
{
    public abstract class DapperConnection<T> : DapperConnection
    {
        public virtual string TableName => typeof(T).Name;
        public virtual string SchemaName => "dbo";

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
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
            var sql = new MySqlConnection(ConfigurationManager.ConnectionStrings[$"Sakari{ConfigurationManager.AppSettings.Get("Environment")}"].ConnectionString);
            sql.Open();
            return sql;
        }

    }
}