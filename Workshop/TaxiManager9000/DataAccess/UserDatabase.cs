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

        public List<User> GetAll()
        {
            return _users;
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
                new User("test", "test", Domain.Enums.Role.Administrator),
                new User("test1", "test", Domain.Enums.Role.Manager),
                new User("test2", "test", Domain.Enums.Role.Maintainance),
                new User("test3", "test", Domain.Enums.Role.Administrator)
            });
        }

        public User GetItemById(int Id)
        {
            return _users.FirstOrDefault(user => user.Id == Id);
        }

        //Ask here what can i do with IUserDatabase and cant use User class
        //public void Insert(IUserDatabase Data)
        //{
        //    throw new NotImplementedException();
        //}

        //List<IUserDatabase> IDatabase<IUserDatabase>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Delete(IUserDatabase Data)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
