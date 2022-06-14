using TimeTracking.DataAccess.Interfaces;
using TimeTracking.Domain.Entities;
using TimeTracking.Services.Interfaces;
using TimeTracking.Shared;

namespace TimeTracking.Services
{
    public class AuthService : IAuthService
    {
        private static IUserDatabase _database;

        public User CurrentUser { get; private set; }

        public AuthService()
        {
            _database = DependencyResolver.GetServices<IUserDatabase>();
        }

        public void LogIn(string username, string password)
        {
            if(string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username can't be empty!");
            }

            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password can't be empty!");
            }

            User currentUser = _database.GetUserByUsernameAndPassword(username, password);

            if(currentUser == null)
            {
                throw new ArgumentException("user does not exist!");
            }

            CurrentUser = currentUser;
        }

        public void Register(string firstName, string lastName, int age, string username, string password)
        {
            if(string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException("Enter a Name!");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException("Enter a Last Name!");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username can't be empty!");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password can't be empty!");
            }

            _database.InsertAsync(new User(firstName, lastName, age, username, password));
        }

        public void LogOut()
        {
            CurrentUser = null;
        }
    }
}
