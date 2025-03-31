using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [ApiController]  
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAll()
        {
            return Ok(await _service.GetProductsAll());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var result= await _service.GetProductById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var newProduct = await _service.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

       
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product  product)
        {
            if (id != product.Id) { return BadRequest(); }
            await _service.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await _service.DeleteProduct(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
