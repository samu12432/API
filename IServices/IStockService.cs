using API_REST_PROYECT.DTOs.Stock;
using API_REST_PROYECT.Models;

namespace API_REST_PROYECT.IServices
{
    public interface IStockService
    {
        Task<IEnumerable<StockDto>> GetAllStock();
        Task<StockDto?> GetStockBySku(string sku);
        Task<bool> CreateStock(StockDto dto);
        Task UpdateStock(StockDto dto);
    }
}
