using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Services.Services.Interfaces
{
    public interface IAdminService
    {

        bool CreateNewUser(string username, string password, Role role);

        bool DeleteUser(int userId);

        List<User> GetAllUsers();

    }
}
