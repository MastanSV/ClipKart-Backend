
using ClipKart.Core.Interfaces.Products;
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
            _productRepository.CreateProduct(product);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<Product> GetPaginatedProducts(int pageSize, int pageIndex)
        {
            return _productRepository.GetPaginatedProducts(pageSize, pageIndex);
        }

        public int GetProductsCount()
        {
            return _productRepository.GetProductsCount();
        }

        public int GetSearchMatchingProductsCount(string searchText)
        {
            return _productRepository.GetSearchMatchingProductsCount(searchText);
        }

        public List<Product> GetProductsBasedOnSearch(string searchText, int pageSize, int pageIndex)
        {
            return _productRepository.GetProductsBasedOnSearch(searchText, pageSize, pageIndex);
        }
    }
}
