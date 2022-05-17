using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Services.Services.Interfaces
{
    public interface IAdminService
    {

        Task<bool> CreateNewUser(string username, string password, Role role);

        Task<bool> DeleteUser(int userId);

        List<User> GetAllUsers();

    }
}
