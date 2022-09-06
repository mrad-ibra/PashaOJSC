using Microsoft.EntityFrameworkCore;
using ProductStockApi.Models;

namespace ProductStockApi.Repository
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
    }
}