using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Interfaces;
using ProductApi.Models;
using ProductApi.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ProductDbContext _context;
        public ProductCategoryRepository(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<ProductCategory> CreateProductCategoryAsync(ProductCategory resource)
        {
            var category = new ProductCategory()
            {
                ProductCategoryName = resource.ProductCategoryName
            };
           await _context.ProductCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<ProductCategory> DeleteProductCategoryAsync(int id)
        {
            var category=await _context.ProductCategories.Where(pc=>pc.ProductCategoryId == id).FirstOrDefaultAsync();
             _context.ProductCategories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<ProductCategory>> GetAllProductCategorysAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            var category =await _context.ProductCategories.Where(pc => pc.ProductCategoryId == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<ProductCategory> UpdateProductCategoryAsync(int id, ProductCategory resource)
        {
            var category = await _context.ProductCategories.FirstOrDefaultAsync(pc => pc.ProductCategoryId == id);
            category.ProductCategoryName=resource.ProductCategoryName;
            _context.ProductCategories.Update(category);
            await _context.SaveChangesAsync();
            return category;

        }
    }
}
