using API_REST_PROYECT.Data;
using API_REST_PROYECT.DTOs.Stock;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST_PROYECT.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ContextDb _contextDb;

        public StockRepository(ContextDb contextDb)
        {

            _contextDb = contextDb;
        }

        public async Task AddAsync(Stock entity)
        {
            _contextDb.Stocks.Add(entity);
            await _contextDb.SaveChangesAsync();
        }

        public async Task UpdateStockAsync(Stock stock)
        {
            _contextDb.Stocks.Update(stock); 
            await _contextDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<Stock>> GetAllStock() =>
            await _contextDb.Stocks.Include(s => s.stockSupply).ToListAsync();

        public async Task<Stock?> GetStockBySku(string sku) =>
            await _contextDb.Stocks.Include(m => m.stockSupply) .FirstOrDefaultAsync(m => m.stockSupply.codeSupply == sku);

    }
}
