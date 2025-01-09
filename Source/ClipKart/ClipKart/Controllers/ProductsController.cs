using ClipKart.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClipKart.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> Index()
        {
            var products = new List<Product> { new Product() { Name = "Dairy", Description = "Write you fascinating things daily", Category = "Stationary", Price = 85 },
            new Product{ Name="iPhone 12 mini", Description="Get closer and closer with your loved ones", Category="Tech/Electronics",Price=39000} };
            return products;
        }
    }
}
