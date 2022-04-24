using TaxiManager9000.Shared.Utils;

namespace TaxiManager9000.Shared.Services
{
    public static class ValidateInput
    {
        private const int USERNAME_MIN_LEGTH = 5;
        private const int PASSWORD_MIN_LEGTH = 5;

        public static bool CheckPassword(string password)
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

        public static bool CheckUserName(string username)
        {

            if (StringUtils.IsEmpty(username)) return false;

            if (StringUtils.CheckMinNumberOfChars(username, USERNAME_MIN_LEGTH)) return false;

            return true;
        }

    }
}
