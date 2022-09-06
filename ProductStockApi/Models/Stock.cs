using ProductStockApi.Response;
using System.ComponentModel.DataAnnotations;

namespace ProductStockApi.Models
{
    public class Stock
    { 
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        [Required]
        public int StockProductId { get; set; }
        
        [Required]
        public int ProductCount { get; set; }
    }
}
