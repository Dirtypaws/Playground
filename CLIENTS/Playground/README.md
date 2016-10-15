# Playground

The Playground project is used mainly for unit tests and console applications. It's a nice place to demonstrate proof-of-concepts

## Projects

### Dapper.Core.Konsole

The Dapper.Core.Konsole project is a demonstration of dotnetcore using Dapper with the CRUD abstraction pattern. Some interesting patterns to display:
* The base lookup object was moved to the Framework project. This was to avoid a circular dependancy between CoreServices (the cache) and Framework.
* There's a new Cache pattern specifically for Lookups. It uses ConcurrentDictionary - so it should be threadsafe. *TODO: Write a test to ensure thread safety*
* The MemoryCache service I updated to dotnetcore. *TODO: Need to test this more*
* The new dotnetcore pattern for configs almost requires the ConfigHelper to be in the framework if you want seperate assemblies to reference the applications settings file.
* I found this sweet SO answer that solved the predicate issue we'd been having in Dapper: http://stackoverflow.com/a/29356694/429593
* The mapping issues we had I solved with Dapper.FastCRUD.
* Now if you want a custom mapper - you'd write it in the constructor for the repository:
```C#
public class PlayerRepository : CRUDRepository<Player>, IPlayerRepository
{
	// I technically don't have to do this because the class name and the table match up - but - if they didn't...
    public override string TableName => "Player";
    // I'd still have to 
    public override string SchemaName => "roster";

    static PlayerRepository()
    {
        OrmConfiguration.GetDefaultEntityMapping<Player>()
            .SetProperty(e => e.ID,
                d => d.SetDatabaseGenerated(DatabaseGeneratedOption.Identity)
                    .SetPrimaryKey()
                    .SetDatabaseColumnName("Id"));
    }
}
```

* I created on the DapperConnection<T> class default resolutions for the table name and schema.
```C#
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
```

* The LookupRepository demonstrates the flexibility of this approach.