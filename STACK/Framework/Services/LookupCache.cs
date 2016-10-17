using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Services
{
    public static class LookupCache
    {
        static readonly ConcurrentDictionary<string, Lookup[]> Cache = new ConcurrentDictionary<string, Lookup[]>();

        public static bool Exists<T>() where T : Lookup => Cache.ContainsKey(typeof(T).Name);

        public static Lookup[] Get<T>() where T : Lookup
        {
            var key = typeof(T).Name;
            Lookup[] data;
            Cache.TryGetValue(key, out data);
            return data;
        }

        public static Lookup[] Set<T>(IEnumerable<Lookup> data) where T : Lookup
        {
            var key = typeof(T).Name;
            Cache.AddOrUpdate(key, a => data.ToArray(), (k, u) => data.ToArray());
            return data.ToArray();
        }

        public static void Clear<T>()
        {
            var key = typeof(T).Name;
            Lookup[] data;
            Cache.TryRemove(key, out data);
        }

        public static void Clear()
        {
            Lookup[] data;
            foreach (var cacheKey in Cache.Keys)
                Cache.TryRemove(cacheKey, out data);
        }
    }
}