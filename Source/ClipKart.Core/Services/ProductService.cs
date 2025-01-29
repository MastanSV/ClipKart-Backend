using Clipkart.Infrastructure.Interfaces;
using ClipKart.Core.Interfaces.Product;
using ClipKart.Core.Models;

namespace ClipKart.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.CreateProductAsync(product);
        }

    }
}
