using System.Collections.Generic;
using transparentProxy.ProductService.Models;

namespace transparentProxy.ProductService.Services
{
    public interface IProductService
    {
        List<ProductItemDto> GetProductList();
        bool AddProduct(ProductItemDto productItem);
    }
}
