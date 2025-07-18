using API_REST_PROYECT.DTOs.Stock;
using API_REST_PROYECT.Models;

namespace API_REST_PROYECT.IRepository
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllStock();
        Task<Stock?> GetStockBySku(string skuSupply);
        Task AddAsync(Stock stock);
        Task UpdateStockAsync(Stock stock);
    }
}
