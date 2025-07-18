namespace API_REST_PROYECT.IServices
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
    }
}
