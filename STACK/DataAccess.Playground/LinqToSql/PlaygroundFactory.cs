using System.Configuration;
using System.Data.Linq.Mapping;

namespace DataAccess.Playground.LinqToSql
{
    public class PlaygroundFactory
    {
        private static readonly string _connectionString;
        private static readonly MappingSource _mappingSource;

        /// <summary>
        /// Static constructor.
        /// </summary>
        /// <remarks>
        /// Static initialization of connectionstring and mappingSource.
        /// This significantly increases performance, primarily due to mappingSource cache.
        /// </remarks>        
        static PlaygroundFactory()
        {
            string env = ConfigurationManager.AppSettings.Get("Environment");
            _connectionString = ConfigurationManager.ConnectionStrings[$"Playground{env}"].ConnectionString;

            var context = new PlaygroundContext(_connectionString);
            _mappingSource = context.Mapping.MappingSource;
        }

        /// <summary>
        /// Rapidly creates a new DataContext using cached connectionstring and mapping source.
        /// </summary>
        /// <returns></returns>
        public static PlaygroundContext CreateContext()
        {
            var db = new PlaygroundContext(_connectionString, _mappingSource);

#if DEBUG_X
            var mw = new MulticastTextWriter();
            mw.Add(new DebugTextWriter());
            mw.Add(new ActionTextWriter(s => _logger.Info(s)));
            
            db.Log = mw;                        
#endif
            //db.Log = Console.Out;

            return db;
        }
    }

}