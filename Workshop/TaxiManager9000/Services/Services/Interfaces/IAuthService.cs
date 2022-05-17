using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IAuthService
    {
        User CurrentUser { get; }

        Task LogInAsync(string username, string password);

        Task UpdateUserAsync(User user);
    }
}
