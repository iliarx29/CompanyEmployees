namespace Entities.Exceptions
{
    public class RefreshTokenException : Exception
    {
        public RefreshTokenException()
            : base("Invalid client request. TokenDto has invalid options.")
        { }
    }
}
