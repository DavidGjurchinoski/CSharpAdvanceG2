namespace TaxiManager9000.Domain.Exceptions
{
    public class UserNotCreatedExeption : Exception
    {
        public UserNotCreatedExeption(string? message) : base(message)
        {
        }
    }
}
