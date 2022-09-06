using ProductApi.Models;
using ProductApi.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetAllProductCategorysAsync();
        Task<ProductCategory> GetProductCategoryByIdAsync(int id);
        Task<ProductCategory> CreateProductCategoryAsync(ProductCategory resource);
        Task<ProductCategory> UpdateProductCategoryAsync(int id, ProductCategory resource);
        Task<ProductCategory> DeleteProductCategoryAsync(int id);
    }
}
