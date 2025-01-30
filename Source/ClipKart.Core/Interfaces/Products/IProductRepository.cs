using System;
using ClipKart.Core.Models;

namespace ClipKart.Core.Interfaces.Products
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Product product);
    }
}
