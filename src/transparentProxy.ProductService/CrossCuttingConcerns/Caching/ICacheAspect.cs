using Microsoft.Extensions.Caching.Memory;

namespace transparentProxy.ProductService.CrossCuttingConcerns.Caching
{
    interface ICacheAspect
    {
        object OnBefore(IMemoryCache memoryCache, string cacheKey);
        void OnAfter(object value, IMemoryCache memoryCache, string cacheKey);
    }
}
