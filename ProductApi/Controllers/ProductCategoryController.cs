using Microsoft.AspNetCore.Mvc;
using ProductApi.Interfaces;
using ProductApi.Models;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _category;
        public ProductCategoryController(IProductCategoryRepository category)
        {
            _category = category;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            return Ok(await _category.GetAllProductCategorysAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var category = await _category.GetProductCategoryByIdAsync(id);
            if (category == null) return BadRequest();
            return Ok(category);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] ProductCategory resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await _category.CreateProductCategoryAsync(resource));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] ProductCategory resource)
        {
            if (!ModelState.IsValid) return BadRequest();
            var category = await _category.GetProductCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(await _category.UpdateProductCategoryAsync(id, resource));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var category = await _category.GetProductCategoryByIdAsync(id);
            if (category == null) return BadRequest();
            return Ok(await _category.DeleteProductCategoryAsync(id));
        }
    }
}
