using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Interfaces;
using ProductApi.Models;
using ProductApi.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;
        public ProductController(IProductRepository product)
        {
            _product=product;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            return Ok(await _product.GetAllProductsAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
           var product=await _product.GetProductByIdAsync(id);
            if (product == null) return BadRequest();
            return Ok(product);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProductAsync([FromBody]ProductResource resource)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await _product.CreateProductAsync(resource));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] ProductResource resource)
        {
            if (!ModelState.IsValid) return BadRequest();
           var product=await _product.GetProductByIdAsync(id);
            if(product == null) return NotFound();
            return Ok(await _product.UpdateProductAsync(id, resource));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var product = await _product.GetProductByIdAsync(id);
            if (product == null) return BadRequest();
            return Ok(await _product.DeleteProductAsync(id));
        }
    }
}
