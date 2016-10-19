using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Services
{
    public static class LookupCache
    {
        static readonly ConcurrentDictionary<string, Lookup[]> Cache = new ConcurrentDictionary<string, Lookup[]>();

        public static bool Exists<T>() where T : Lookup => Cache.ContainsKey(typeof(T).Name);

        /// <summary>
        /// Get an array of Lookups from the cache. Use the predicate to filter the result
        /// </summary>
        /// <typeparam name="T">The BusinessObject that inherits from Lookup</typeparam>
        /// <param name="filter">Apply a predicate to the get operation to filter the results</param>
        /// <returns></returns>
        public static Lookup[] Get<T>(Expression<Func<Lookup, bool>> filter = null) where T : Lookup
        {
            var key = typeof(T).Name;
            Lookup[] data;
            Cache.TryGetValue(key, out data);

            if (filter != null)
                data = data.AsQueryable()
                    .Where(filter)
                    .ToArray();

            return data;
        }

        /// <summary>
        /// Adds a collection of BusinessObjects to the cache for faster retrieval
        /// </summary>
        /// <typeparam name="T">The BusinessObject that inherits from Lookup</typeparam>
        /// <param name="data">The data to be cached in the key</param>
        /// <returns></returns>
        public static Lookup[] Set<T>(IEnumerable<Lookup> data) where T : Lookup
        {
            var key = typeof(T).Name;
            Cache.AddOrUpdate(key, a => data.ToArray(), (k, u) => data.ToArray());
            return data.ToArray();
        }

        /// <summary>
        /// Clears all objects of the specified type
        /// </summary>
        /// <typeparam name="T">The BusinessObject that inherits from Lookup</typeparam>
        public static void Clear<T>()
        {
            var key = typeof(T).Name;
            Lookup[] data;
            Cache.TryRemove(key, out data);
        }
        
        /// <summary>
        /// Clears all cached lookups
        /// </summary>
        public static void Clear()
        {
            Lookup[] data;
            foreach (var cacheKey in Cache.Keys)
                Cache.TryRemove(cacheKey, out data);
        }
    }
}