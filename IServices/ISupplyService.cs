namespace API_REST_PROYECT.IServices
{
    public interface ISupplyService<TDto>
    {
        Task<TDto> AddSupplyAsync(TDto t);
    }
}
