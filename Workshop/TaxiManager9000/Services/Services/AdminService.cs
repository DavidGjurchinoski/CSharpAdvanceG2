using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Services.Services.Interfaces;
using TaxiManager9000.Shared;
using TaxiManager9000.Shared.Utils;

namespace TaxiManager9000.Services.Services
{
    public class AdminService : IAdminService
    {
        private const int USERNAME_MIN_LEGTH = 5;
        private const int PASSWORD_MIN_LEGTH = 5;

        private readonly IUserDatabase _dataBase;

        public AdminService()
        {
            _dataBase = DependencyResolver.GetService<IUserDatabase>();
        }

        public bool CreateNewUser(User user)
        {
            _dataBase.PrintUsers();

            if (CheckPassword(user.Password) && CheckUserName(user.UserName))
            {

                _dataBase.Insert(user);

                _dataBase.PrintUsers();

                return true;
            }

            throw new UserNotCreatedExeption("User not created");

        }

        public bool DeleteUser()
        {
            Console.WriteLine("Choose a user by id to delete");

            _dataBase.PrintUsers();

            string userId = Console.ReadLine();

            if(int.TryParse(userId, out int userIdInt))
            {
                User pickedUser = _dataBase.GetUserById(userIdInt);

                _dataBase.Delete(pickedUser);

                Console.WriteLine("After deleting");
                _dataBase.PrintUsers();

                return true;
            } 
            else
            {
                Console.WriteLine("Invalid Input");

                return false;
            };

        }

        private bool CheckPassword(string password)
        {
            bool hasNum = false;
            bool hasLetter = false;

            if (StringUtils.IsEmpty(password)) return false;

            if (StringUtils.CheckMinNumberOfChars(password, PASSWORD_MIN_LEGTH)) return false;


            foreach (char character in password)
            {
                if (char.IsDigit(character)) hasNum = true;

                if (char.IsLetter(character)) hasLetter = true;
            }

            return hasLetter && hasNum;

        }

        private bool CheckUserName(string username)
        {

            if (StringUtils.IsEmpty(username)) return false;

            if (StringUtils.CheckMinNumberOfChars(username, USERNAME_MIN_LEGTH)) return false;

            return true;
        }

    }
}
