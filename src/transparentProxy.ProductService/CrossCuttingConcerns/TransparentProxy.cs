using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace transparentProxy.ProductService.CrossCuttingConcerns
{
    public class TransparentProxy<T> : DispatchProxy
    {
        private T _decorated;
        private IMemoryCache _memoryCache;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            throw new System.NotImplementedException();
        }

        public static T Create(T decorated)
        {
            object proxy = Create<T, TransparentProxy<T>>();
            ((TransparentProxy<T>)proxy).SetParameters(decorated, null);

            return (T)proxy;
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
