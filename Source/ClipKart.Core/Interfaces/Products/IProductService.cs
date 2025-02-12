using ClipKart.Core.Models;

namespace ClipKart.Core.Interfaces.Products
{
    public interface IProductService
    {
        void AddProduct(Product product);

        List<Product> GetProducts();

        List<Product> GetPaginatedProducts(int pageSize, int pageIndex);
    }
}
