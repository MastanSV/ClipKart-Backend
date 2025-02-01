using ClipKart.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Clipkart.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
