using ProductStockApi.Models;

namespace ProductStockApi.Interfaces
{
    public interface IStockRepository
    {
        Stock AddStock(int id, int count);
        Stock RemoveStock(int id, int count);
        Stock GetStock(int id);
    }
}
