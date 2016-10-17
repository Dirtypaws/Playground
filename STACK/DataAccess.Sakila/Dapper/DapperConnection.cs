using System.Data;
using System.Diagnostics.CodeAnalysis;
using Dapper.FastCrud;
using Framework.Helpers;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DataAccess.Sakila.Dapper
{
    public abstract class DapperConnection<T> : DapperConnection
    {
        public virtual string TableName => typeof(T).Name.ToLower();
        public const string SchemaName = "sakila";

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
        static DapperConnection()
        {
            OrmConfiguration.DefaultDialect = SqlDialect.MySql;
        }

        protected static IDbConnection OpenConnection()
        {
            var sql = new MySqlConnection(ConfigurationHelper.Configuration.GetConnectionString("MySql"));
            sql.Open();
            return sql;
        }

    }
}