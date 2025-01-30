using Clipkart.Infrastructure.DbContexts;
using ClipKart.Core.Interfaces.Products;
using ClipKart.Core.Models;

namespace Clipkart.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
