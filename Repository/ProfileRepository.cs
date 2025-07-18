using API_REST_PROYECT.Data;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.Models;
using Profile = API_REST_PROYECT.Models.Profile;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;

namespace API_REST_PROYECT.Repository
{
    public class ProfileRepository : ISupplyRepository<Profile>
    {
        private readonly ContextDb _context;
        
        public ProfileRepository(ContextDb context)
        {
            this._context = context;
        }

        public async Task<Profile> AddAsync(Profile entity)
        {
            _context.Supplies.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Profile?> GetByCodeAsync(string code) =>
            await _context.Profiles.FirstOrDefaultAsync(s => s.codeSupply == code);


        public async Task RemoveAsync(Profile entity)
        {
            _context.Set<Profile>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
