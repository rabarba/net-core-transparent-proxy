using System.Collections.Generic;
using transparentProxy.ProductService.Models;

namespace transparentProxy.ProductService.Services.Impl
{
    public class ProductManager : IProductService
    {
        public bool AddProduct(ProductItemDto productItem)
        {
            // to do stuff ...
            return true;
        }

        public List<ProductItemDto> GetProductList()
        {
            throw new System.NotImplementedException();
        }
    }
}
