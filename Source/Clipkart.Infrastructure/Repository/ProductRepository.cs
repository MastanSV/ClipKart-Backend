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
    }
}
