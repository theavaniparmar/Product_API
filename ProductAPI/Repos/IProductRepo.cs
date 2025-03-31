using ProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Repos
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProductsAll();
        Task<Product> GetProductById(int Id);

        Task<Product> AddProduct(Product product);

        Task<Product> UpdateProduct(Product product); 
        Task<bool> DeleteProduct(int Id);
    }
}
