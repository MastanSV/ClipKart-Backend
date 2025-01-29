using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClipKart.Core.Models;

namespace Clipkart.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Product product);
    }
}
