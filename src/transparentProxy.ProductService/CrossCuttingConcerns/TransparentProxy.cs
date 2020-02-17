using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using transparentProxy.ProductService.CrossCuttingConcerns.Caching;
using transparentProxy.ProductService.CrossCuttingConcerns.Logging;

namespace transparentProxy.ProductService.CrossCuttingConcerns
{
    public class TransparentProxy<T> : DispatchProxy
    {
        private T _decorated;
        private IMemoryCache _memoryCache;

        protected override object Invoke(MethodInfo method, object[] args)
        {
            var aspects = method.GetCustomAttributes(typeof(IAspect), true);

            object response = CheckCache(aspects, _memoryCache);
            if (response != null)
            {              
                return response;
            }

            var result = method.Invoke(_decorated, args);

            Log($"Response: {JsonConvert.SerializeObject(result)}", aspects, _memoryCache);
            SetCache(result, aspects, _memoryCache);

            return result;
        }

        private object CheckCache(IEnumerable<object> aspects, IMemoryCache memoryCache)
        {

            foreach (var aspect in aspects)
            {
                if (aspect is ICacheAspect cacheAspect)
                {
                    return cacheAspect.OnBefore(memoryCache, "product_item_list");
                }
            }

            return null;
        }

        private void SetCache(object result, IEnumerable<object> aspects, IMemoryCache memoryCache)
        {
            foreach (var aspect in aspects)
            {
                if (aspect is ICacheAspect cacheAspect)
                {
                    cacheAspect.OnAfter(result, memoryCache, "product_item_list");
                }
            }
        }

        private void Log(string logMessage, IEnumerable<object> aspects, IMemoryCache memoryCache)
        {
            foreach (var aspect in aspects)
            {
                if (aspect is ILogAspect logAspect)
                {
                    var logKey = new Guid();
                    logAspect.Log(memoryCache, logKey.ToString(), logMessage);
                }
            }
        }

        public static T Create(T decorated, IMemoryCache memoryCache)
        {
            object proxy = Create<T, TransparentProxy<T>>();
            ((TransparentProxy<T>)proxy).SetParameters(decorated, memoryCache);

            return (T)proxy;
        }

        private void SetParameters(T decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }
    }
}
