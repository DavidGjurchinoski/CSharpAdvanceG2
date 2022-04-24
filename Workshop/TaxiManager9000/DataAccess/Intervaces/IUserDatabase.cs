using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess.Intervaces
{
    public interface IUserDatabase : IDatabase<User>
    {

        User GetByUserNameAndPassword(string userName, string password);


    }
}
