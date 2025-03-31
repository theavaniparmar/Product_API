using ProductAPI.Models;
using ProductAPI.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {


        private readonly IProductRepo _repo;

        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> GetProductsAll() => await _repo.GetProductsAll();
        public async Task<Product> GetProductById(int id) => await _repo.GetProductById(id);
        public async Task<Product> AddProduct(Product product) => await _repo.AddProduct(product);
        public async Task<Product> UpdateProduct(Product product) => await _repo.UpdateProduct(product);
        public async Task<bool> DeleteProduct(int id) => await _repo.DeleteProduct(id);

    }
}

