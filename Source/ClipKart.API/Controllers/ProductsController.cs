
using ClipKart.Core.Interfaces.Products;
using ClipKart.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClipKart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(new {message = "This is protected data!", products = products});
        }

        [HttpGet("GetProducts/{pageSize}/{pageIndex}")]
        public IActionResult GetPaginationData(int pageSize, int pageIndex)
        {
            var products = _productService.GetPaginatedProducts(pageSize, pageIndex);
            return Ok(new { message = $"Got paginated data successfully. page-size={pageSize}, page-index={pageIndex}", products = products });
        }
    }
}
