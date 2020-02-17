using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using transparentProxy.ProductService.CrossCuttingConcerns;
using transparentProxy.ProductService.Models;
using transparentProxy.ProductService.Services;
using transparentProxy.ProductService.Services.Impl;

namespace transparentProxy.ProductService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        public ProductsController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductItemDto productItemDto)
        {
            var productService = TransparentProxy<IProductService>.Create(new ProductManager(_memoryCache), _memoryCache);
            productService.AddProduct(productItemDto);

            return Created(string.Empty, true);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productService = TransparentProxy<IProductService>.Create(new ProductManager(_memoryCache), _memoryCache);
            var result = productService.GetProductList();

            return Ok(result);
        }
    }
}