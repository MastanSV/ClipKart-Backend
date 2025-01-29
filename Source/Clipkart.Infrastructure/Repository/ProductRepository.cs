using Clipkart.Infrastructure.DbContexts;
using Clipkart.Infrastructure.Interfaces;
using ClipKart.Core.Models;

namespace Clipkart.Infrastructure.Repository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
