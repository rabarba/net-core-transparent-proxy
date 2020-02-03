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
            var productService = TransparentProxy<IProductService>.Create(new ProductManager());
            var result = productService.AddProduct(productItemDto);

            return Created(string.Empty, result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productService = TransparentProxy<IProductService>.Create(new ProductManager(), _memoryCache);
            var result = productService.GetProductList();

            return Ok(result);
        }
    }
}