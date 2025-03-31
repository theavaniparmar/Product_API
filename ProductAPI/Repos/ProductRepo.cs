using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepo(AppDbContext appDbContext) { _appDbContext = appDbContext; }

        public async Task<IEnumerable<Product>> GetProductsAll()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _appDbContext.Products.FindAsync(id);
        }

        public async Task<Product> AddProduct(Product product)
        {
             _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var Product = await _appDbContext.Products.FindAsync(id);

            if (Product != null)
            {
                _appDbContext.Products.Remove(Product);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

    }
}
