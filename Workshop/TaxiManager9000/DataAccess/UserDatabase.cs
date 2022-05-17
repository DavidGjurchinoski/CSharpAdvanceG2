using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class UserDatabase : FileDataBase<User>, IUserDatabase
    {
        public UserDatabase() : base()
        {
            Task seedTask = new Task(() => Seed());
            seedTask.Start();
            seedTask.Wait();
        }

        public async Task<User> GetByUserNameAndPassword(string username, string password)
        {
            return Items.FirstOrDefault(user => user.UserName == username &&
                                                 user.Password == password);
        }

        private async void Seed()
        {
                await InsertAsync(new User("test", "test", Domain.Enums.Role.Administrator));
                await InsertAsync(new User("test1", "test", Domain.Enums.Role.Manager));
                await InsertAsync(new User("test2", "test", Domain.Enums.Role.Maintainance));
                await InsertAsync(new User("test3", "test", Domain.Enums.Role.Administrator));
        }


    }
}
