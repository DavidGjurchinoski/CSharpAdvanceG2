using TimeTracking.DataAccess.Interfaces;
using TimeTracking.Domain.Entities;

namespace TimeTracking.DataAccess
{
    public class UserDatabase : Database<User>, IUserDatabase
    {
        public UserDatabase()
        {
            if (Items.Count == 0)
            {
                Task.Run( async () => await SeedAsync()).Wait();
            }
        }

        private async Task SeedAsync()
        {
            await InsertAsync(new User("Test1", "LTest1", 18, "test1", "Test1"));
            await InsertAsync(new User("Test2", "LTest2", 19, "test2", "Test2"));
            await InsertAsync(new User("Test3", "LTest3", 20, "test3", "Test3"));
            await InsertAsync(new User("Test4", "LTest4", 30, "test4", "Test4"));
            await InsertAsync(new User("Test5", "LTest5", 45, "test5", "Test5"));
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return Items.FirstOrDefault(user => user.Username == username && user.Passwrod == password);
        }

        public bool CheckUsernameAvailable(string username)
        {
            return Items.Any(user => user.Username == username);
        }
    }
}
