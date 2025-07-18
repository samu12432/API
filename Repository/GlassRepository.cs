using API_REST_PROYECT.Data;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST_PROYECT.Repository
{
    public class GlassRepository : ISupplyRepository<Glass>
    {
        private readonly ContextDb _context;

        public GlassRepository(ContextDb context)
        {
            this._context = context;
        }

        public async Task<Glass> AddAsync(Glass entity)
        {
            _context.Supplies.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Glass?> GetByCodeAsync(string code) =>
            await _context.Glasses.FirstOrDefaultAsync(s => s.codeSupply == code);


        public async Task RemoveAsync(Glass entity)
        {
            _context.Set<Glass>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}