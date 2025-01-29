
using ClipKart.Core.Interfaces.Product;
using ClipKart.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClipKart.API.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IProductService productService)
        {

        }

        [HttpGet]
        public List<Product> Index()
        {
            var products = new List<Product> { new Product() { Name = "Dairy", Description = "Write your fascinating things daily", Category = "Stationary", Price = 85 },
            new Product{ Name="iPhone 12 mini", Description="Get closer and closer with your loved ones", Category="Tech/Electronics",Price=39000} };
            return products;
        }
    }
}
