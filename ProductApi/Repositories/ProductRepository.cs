using AutoMapper;
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
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Product> CreateProductAsync(ProductResource resource)
        {
            var products = _mapper.Map<ProductResource, Product>(resource);
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
            return products;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
           var product=await _context.Products.Where(product=>product.ProductId==id).FirstOrDefaultAsync();
            product.IsDeleted=false;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Where(product=>product.IsDeleted==true).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.ProductId == id && product.IsDeleted==true);
        }

        public async Task<Product> UpdateProductAsync(int id, ProductResource resource)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.ProductId == id);
            product.ProductName = resource.ProductName;
            product.ProductCategoryId = resource.ProductCategoryId;
            product.Price = resource.Price;
            product.State = resource.State;
             _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
