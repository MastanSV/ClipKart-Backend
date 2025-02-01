
using ClipKart.Core.Interfaces.Products;
using ClipKart.Core.Models;
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

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpGet]
        [Route("GetProducts")]
        public List<Product> GetProducts()
        {
            return _productService.GetProducts();
        }
    }
}
