using TimeTracking.Domain.Entities;

namespace TimeTracking.DataAccess.Interfaces
{
    public interface IUserDatabase : IDatabase<User>
    {
        User GetUserByUsernameAndPassword(string username, string password);

        bool CheckUsernameAvailable(string username);
    }
}
