using API_REST_PROYECT.Data;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST_PROYECT.Repository
{
    public class AccessoryRepository : ISupplyRepository<Accessory>
    {
        private readonly ContextDb _context;

        public AccessoryRepository(ContextDb context)
        {
            this._context = context;
        }

        public async Task<Accessory> AddAsync(Accessory entity)
        {
            _context.Supplies.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Accessory?> GetByCodeAsync(string code) =>
            await _context.Accessories.FirstOrDefaultAsync(s => s.codeSupply == code);


        public async Task RemoveAsync(Accessory entity)
        {
            _context.Set<Accessory>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
