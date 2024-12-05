using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Microsoft.Extensions.Caching.Memory;

namespace Orchard.Caching
{
    public interface ICacheManager
    {
        TResult Get<TResult>(string key, Func<AcquireContext<TResult>, TResult> acquire);
        void Put<T>(string key, T value);
        void Remove(string key);
        void Clear();
    }
    public class CacheManager : ICacheManager
        private readonly IMemoryCache _memoryCache;
        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public TResult Get<TResult>(string key, Func<AcquireContext<TResult>, TResult> acquire)
            if (_memoryCache.TryGetValue(key, out TResult result))
            {
                return result;
            }
            var context = new AcquireContext<TResult> { Key = key };
            result = acquire(context);
            _memoryCache.Set(key, result);
            return result;
        public void Put<T>(string key, T value)
            _memoryCache.Set(key, value);
        public void Remove(string key)
            _memoryCache.Remove(key);
        public void Clear()
            if (_memoryCache is MemoryCache memoryCache)
                memoryCache.Compact(1.0);
}
