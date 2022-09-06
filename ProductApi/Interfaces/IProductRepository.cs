using ProductApi.Models;
using ProductApi.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(ProductResource resource);
        Task<Product> UpdateProductAsync(int id, ProductResource resource);
        Task<Product> DeleteProductAsync(int id);
    }
}
