using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Services.Services.Interfaces;
using TaxiManager9000.Shared;
using TaxiManager9000.Shared.Services;

namespace TaxiManager9000.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserDatabase _dataBase;

        public AdminService()
        {
            _dataBase = DependencyResolver.GetService<IUserDatabase>();
        }

        public async Task<bool> CreateNewUser(string username, string password, Role role)
        {

            if (ValidateInput.CheckPassword(password) && ValidateInput.CheckUserName(username))
            {
                await _dataBase.InsertAsync(new User(username, password, role));

                return true;
            }

            return false;
            //throw new UserNotCreatedExeption("User not created");

        }

        public async Task<bool> DeleteUser(int userId)
        {
            User pickedUser = _dataBase.GetItemById(userId);

            return await _dataBase.DeleteAsync(pickedUser);
        }

        public List<User> GetAllUsers()
        {
            return _dataBase.GetAll();
        }
    }
}
