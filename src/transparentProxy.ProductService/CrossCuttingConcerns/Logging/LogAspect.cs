using Microsoft.Extensions.Caching.Memory;
using System;

namespace transparentProxy.ProductService.CrossCuttingConcerns.Logging
{
    public class LogAspect : Attribute, ILogAspect, IAspect
    {
        public void Log(IMemoryCache memoryCache, string logKey, string logMessage)
        {
            memoryCache.Set(logKey, logMessage);
        }
    }
}
