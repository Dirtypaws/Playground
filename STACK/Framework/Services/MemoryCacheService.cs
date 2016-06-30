using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Framework.Services
{
    public class MemoryCacheService
    {
        static readonly ObjectCache _cache = MemoryCache.Default;

        /// <summary>
        /// Gets the amount of memory on the computer, in bytes
        /// </summary>
        /// <returns></returns>
        public static long GetCacheMemoryLimit()
        {
            return MemoryCache.Default.CacheMemoryLimit;
        }

        /// <summary>
        /// Gets the percentage of physical memory that the cache can use
        /// </summary>
        /// <returns></returns>
        public static long GetPhysicalMemoryLimit()
        {
            return MemoryCache.Default.PhysicalMemoryLimit;
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public static T Get<T>(string key) where T : class
        {
            try { return (T)_cache[key]; }
            catch { return null; }
        }

        /// <summary>
        /// Insert item into the cache
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// /// <param name="offset">Cache expiration</param>
        public static void Add<T>(T objectToCache, string key, DateTimeOffset offset) where T : class
        {
            // _cache.Add(key, objectToCache, DateTime.Now.AddMinutes(60));
            _cache.Add(key, objectToCache, offset);
        }

        /// <summary>
        /// Insert item into the cache
        /// </summary>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="offset">Cache expiration</param>
        public static void Add(object objectToCache, string key, DateTimeOffset offset)
        {
            // _cache.Add(key, objectToCache, DateTime.Now.AddMinutes(60));
            _cache.Add(key, objectToCache, offset);
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public static void Clear(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Remove all items from cache in the specified array
        /// </summary>
        public static void Clear(string[] keys)
        {
            foreach (var key in keys)
                Clear(key);
        }

        /// <summary>
        /// Remove all items from cache
        /// </summary>
        public static void ClearAll()
        {
            var keys = _cache.Select(kvp => kvp.Key).ToList();

            foreach (var key in keys)
                _cache.Remove(key);
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return _cache.Get(key) != null;
        }

        /// <summary>
        /// Gets all cached keys
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAll()
        {
            return _cache.Select(kvp => kvp.Key).ToList();
        }

    }
}
