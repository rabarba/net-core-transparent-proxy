using System;
using Microsoft.Extensions.Caching.Memory;

namespace transparentProxy.ProductService.CrossCuttingConcerns.Caching
{
    public class CacheAspect : Attribute, ICacheAspect, IAspect
    {
        public int DurationInMinute { get; set; }

        public void OnAfter(object value, IMemoryCache memoryCache, string cacheKey)
        {
            memoryCache.Set(cacheKey, value, new DateTimeOffset(DateTime.Now.AddMinutes(DurationInMinute)));
        }

        public object OnBefore(IMemoryCache memoryCache, string cacheKey)
        {
            return memoryCache.Get(cacheKey);
        }
    }
}
