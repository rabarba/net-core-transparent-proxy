using Microsoft.Extensions.Caching.Memory;

namespace transparentProxy.ProductService.CrossCuttingConcerns.Logging
{
    interface ILogAspect
    {
        void Log(IMemoryCache memoryCache, string logKey, string logMessage);
    }
}
