using Microsoft.Extensions.Caching.Memory;
using transparentProxy.ProductService.Models;

namespace transparentProxy.ProductService.Services.Impl
{
    public class ProductManager : IProductService
    {
        private IMemoryCache _memoryCache;

        public ProductManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public ProductItemDto AddProduct(ProductItemDto productItem)
        {
            _memoryCache.Set("product_item_list", productItem);
            return productItem;
        }

        public ProductItemDto GetProductList()
        {
            return null;
        }
    }
}
