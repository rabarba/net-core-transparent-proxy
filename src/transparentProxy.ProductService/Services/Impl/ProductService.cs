using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using transparentProxy.ProductService.Models;

namespace transparentProxy.ProductService.Services.Impl
{
    public class ProductManager : IProductService
    {
        private readonly IMemoryCache _memoryCache;
        public ProductManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddProduct(ProductItemDto productItem)
        {
            _memoryCache.Set("product_item_list", productItem);
        }

        public List<ProductItemDto> GetProductList()
        {
            return null;
        }
    }
}
