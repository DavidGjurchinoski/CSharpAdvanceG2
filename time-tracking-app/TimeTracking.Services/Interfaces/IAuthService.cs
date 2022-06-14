using TimeTracking.Domain.Entities;

namespace TimeTracking.Services.Interfaces
{
    public interface IAuthService
    {
        User CurrentUser { get; }

        void LogIn(string userName, string password);

        void Register(string firstName, string lastName, int age, string username, string password);

        void LogOut();
    }
}
