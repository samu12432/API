namespace API_REST_PROYECT.Exceptions.Register
{
    public class EmailException : RegisterException
    {
        public EmailException() { }

        public EmailException(string message) : base(message) { }
    }
}
