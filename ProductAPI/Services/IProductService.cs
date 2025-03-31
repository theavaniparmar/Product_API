using ProductAPI.Models;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAll();
        Task<Product> GetProductById(int Id);

        Task<Product> AddProduct(Product product);

        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int Id);
        
    }
}

