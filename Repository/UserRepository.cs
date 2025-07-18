
using API_REST_PROYECT.Data;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_REST_PROYECT.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDb _context;

        public UserRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.userEmail == email);

        public async Task AddAsync(User user) =>
            await _context.Users.AddAsync(user);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        public async Task<User?> GetUserByInfo(string userName) =>
            await _context.Users.FirstOrDefaultAsync(u => u.userName == userName);

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await SaveChangesAsync();
        }
    }
}
