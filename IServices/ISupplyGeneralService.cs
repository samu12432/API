namespace API_REST_PROYECT.IServices
{
    public interface ISupplyGeneralService
    {
        Task<string> RemoveSupplyAsync(string codeSupply);
    }
}
