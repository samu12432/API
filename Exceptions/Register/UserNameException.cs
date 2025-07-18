namespace API_REST_PROYECT.Exceptions.Register
{
    public class UserNameException : RegisterException
    {
        public UserNameException() { }
        public UserNameException(string message) : base(message) { }
    }
}
