using System.Collections.Generic;

namespace transparentProxy.ProductService.Models
{
    public class ProductDto
    {
        public List<ProductItemDto> ProductItems { get; set; }
    }

    public class ProductItemDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
