using Clipkart.Infrastructure.DbContexts;
using ClipKart.Core.Interfaces.Products;
using ClipKart.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Clipkart.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetPaginatedProducts(int pageSize, int pageIndex)
        {
            int skipSize = CalculateSkipSize(pageSize, pageIndex);
            return _context.Products.OrderBy(product => product.Id).Skip(skipSize).Take(pageSize).ToList();
        }

        public int GetProductsCount()
        {
            return _context.Products.Count();
        }

        public List<Product> GetProductsBasedOnSearch(string searchText, int pageSize, int pageIndex)
        {
            int skipSize = CalculateSkipSize(pageSize, pageIndex);
            var products = _context.Products.Where(item => item.Name.ToLower().Contains(searchText.ToLower())).OrderBy(product => product.Id).Skip(skipSize).Take(pageSize).ToList();
            return products;
        }

        private int CalculateSkipSize(int pageSize, int pageIndex)
        {
            return (pageIndex - 1) * pageSize;
        }

        public int GetSearchMatchingProductsCount(string searchText)
        {
            return _context.Products.Where(product => product.Name.Contains(searchText)).Count();
        }
    }
}
