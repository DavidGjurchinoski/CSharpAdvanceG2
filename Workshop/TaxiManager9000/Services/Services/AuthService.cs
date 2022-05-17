using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Shared;

namespace TaxiManager9000.Services
{
    public class AuthService : IAuthService
    {
        public User CurrentUser { get; private set; }

        private static IUserDatabase _database;

        public AuthService()
        {
            _database = DependencyResolver.GetService<IUserDatabase>();
        }

        public async Task LogInAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username is empty");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password is empty");
            }

            User currentUser = await _database.GetByUserNameAndPassword(username, password);

            if (currentUser == null)
            {
                throw new InvalidCredentialsException("Invalid credentials");
            }

            CurrentUser = currentUser;
        }

        public async Task UpdateUserAsync(User user)
        {
            _database.UpdateAsync(user);
        }
    }
}
