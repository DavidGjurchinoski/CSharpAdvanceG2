using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class UserDatabase : IUserDatabase
    {
        private readonly List<User> _users;

        public UserDatabase()
        {
            _users = new List<User>();
            Seed();
            _users.ForEach(u => AutoIncrementId(u));
        }

        public void Insert(User user)
        {
            User userToInsert = AutoIncrementId(user);

            _users.Add(userToInsert);
        }

        public bool Delete(User user)
        {
            return _users.Remove(user);
        }

        public void PrintUsers()
        {
            _users.ForEach(user => Console.WriteLine($"{user.Id}. {user.UserName} {user.Role}"));
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            return _users.FirstOrDefault(user => user.UserName == username &&
                                                 user.Password == password);
        }

        private User AutoIncrementId(User user)
        {
            int currentId = 0;

            if (_users.Count > 0)
            {
                currentId = _users.OrderByDescending(x => x.Id).First().Id;
            }

            user.Id = ++currentId;

            return user;
        }

        private void Seed()
        {
            _users.AddRange(new List<User>()
            {
                //This does not work it sets all the users ids to 1
                //AutoIncrementId(new User("test", "test", Domain.Enums.Role.Administrator)),
                //AutoIncrementId(new User("test1", "test", Domain.Enums.Role.Manager)),
                //AutoIncrementId(new User("test2", "test", Domain.Enums.Role.Maintainance)),
                //AutoIncrementId(new User("test3", "test", Domain.Enums.Role.Administrator))
                new User("test", "test", Domain.Enums.Role.Administrator),
                new User("test1", "test", Domain.Enums.Role.Manager),
                new User("test2", "test", Domain.Enums.Role.Maintainance),
                new User("test3", "test", Domain.Enums.Role.Administrator)
            });
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
    }
}
