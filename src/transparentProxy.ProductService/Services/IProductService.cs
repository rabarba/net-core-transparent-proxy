using System.Collections.Generic;
using transparentProxy.ProductService.Models;

namespace transparentProxy.ProductService.Services
{
    public interface IProductService
    {
        List<ProductItemDto> GetProductList();
        void AddProduct(ProductItemDto productItem);
    }
}
