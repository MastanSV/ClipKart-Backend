
using ClipKart.Core.Interfaces.Products;
using ClipKart.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClipKart.API.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Index()
        {
            var products = new List<Product> { new Product() { Name = "Dairy", Description = "Write your fascinating things daily", Category = "Stationary", Price = 85 },
            new Product{ Name="iPhone 12 mini", Description="Get closer and closer with your loved ones", Category="Tech/Electronics",Price=39000} };
            return products;
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }
    }
}
