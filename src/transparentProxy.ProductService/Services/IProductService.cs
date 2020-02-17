using System.Collections.Generic;
using transparentProxy.ProductService.CrossCuttingConcerns.Caching;
using transparentProxy.ProductService.CrossCuttingConcerns.Logging;
using transparentProxy.ProductService.Models;

namespace transparentProxy.ProductService.Services
{
    public interface IProductService
    {
        [CacheAspect(DurationInMinute = 60)]
        ProductItemDto GetProductList();

        [LogAspect]
        ProductItemDto AddProduct(ProductItemDto productItem);
    }
}
