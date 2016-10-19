using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Framework.Services
{
    public class MemoryCacheService
    {
        static readonly IMemoryCache Cache = new MemoryCache(new MemoryCacheOptions());
        static readonly ConcurrentDictionary<string, CancellationTokenSource> Keys = new ConcurrentDictionary<string, CancellationTokenSource>();

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public static T Get<T>(string key) where T : class
        {
            try { return (T)Cache.Get(key); }
            catch { return null; }
        }

        /// <summary>
        /// Insert item into the cache
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="slide">Remove from cache if not accessed in the specified time (UTC)</param>
        /// <param name="expiresAt">Expire the object at the specified time</param>
        public static void Set<T>(T objectToCache, string key, DateTime? expiresAt = null, TimeSpan? slide = null) where T : class
        {
            var options = new MemoryCacheEntryOptions();

            if (expiresAt.HasValue)
            {
                options.SetAbsoluteExpiration(expiresAt.Value - DateTime.UtcNow);
            }

            if (slide.HasValue)
            {
                options.SetSlidingExpiration(slide.Value);
            }

            var cts = new CancellationTokenSource();
            options.AddExpirationToken(new CancellationChangeToken(cts.Token));
            options.RegisterPostEvictionCallback((echoKey, value, reason, substate) =>
            {
                Debug.WriteLine(echoKey + ": '" + value + "' was evicted due to " + reason);
            });

            Cache.Set(key, objectToCache, options);

            Keys.AddOrUpdate(key, c => cts, (k,v) => cts);
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public static void Clear(string key)
        {
            // Trigger the cancel of the cancellation token - because that will write to the logger.
            Keys[key].Cancel();

            // Remove it from the cancellation keys 
            CancellationTokenSource cts;
            Keys.TryRemove(key, out cts);
        }

        /// <summary>
        /// Remove all items from cache in the specified array
        /// </summary>
        public static void Clear(string[] cacheKeys)
        {
            foreach (var key in cacheKeys.Where(x => Keys.ContainsKey(x)))
                Clear(key);
        }

        /// <summary>
        /// Remove all items from cache
        /// </summary>
        public static void ClearAll()
        {
            Clear(GetAll());
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return Cache.Get(key) != null;
        }

        /// <summary>
        /// Gets all cached keys
        /// </summary>
        /// <returns></returns>
        public static string[] GetAll()
        {
            return Keys.Select(x => x.Key).ToArray();
        }

    }
}