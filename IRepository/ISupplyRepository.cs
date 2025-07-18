using API_REST_PROYECT.Models;

namespace API_REST_PROYECT.IRepository
{
    public interface ISupplyRepository<T> where T : Supply
    {
        Task<T?> GetByCodeAsync(string codeSupply);
        Task<T> AddAsync(T entity);
        Task RemoveAsync(T entity);
    }
}