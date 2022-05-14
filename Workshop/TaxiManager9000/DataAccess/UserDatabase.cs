using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class UserDatabase : FileDataBase<User>, IUserDatabase
    {
        public UserDatabase() : base()
        {
            Seed();
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            return Items.FirstOrDefault(user => user.UserName == username &&
                                                 user.Password == password);
        }

        private async void Seed()
        {
                new User("test", "test", Domain.Enums.Role.Administrator),
                new User("test1", "test", Domain.Enums.Role.Manager),
                new User("test2", "test", Domain.Enums.Role.Maintainance),
                await InsertAsync(new User("test3", "test", Domain.Enums.Role.Administrator));
        }


    }
}
