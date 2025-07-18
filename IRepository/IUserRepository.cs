using API_REST_PROYECT.Models;

namespace API_REST_PROYECT.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetUserByInfo(string nameUser);
        Task AddAsync(User user);
        Task SaveChangesAsync();
        Task UpdateAsync(User user);
    }
}
