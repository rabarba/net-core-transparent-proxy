using System.Reflection;

namespace transparentProxy.ProductService.CrossCuttingConcerns
{
    public class TransparentProxy<T> : DispatchProxy
    {
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}
