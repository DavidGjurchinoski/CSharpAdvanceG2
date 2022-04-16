namespace TaxiManager9000.Shared.Utils
{
    public static class StringUtils
    {

        public static bool IsEmpty(this string input)
        {
            if (string.IsNullOrEmpty(input) && string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Password can't be empty!");

                return true;
            }

            return false;
        }

        public static bool CheckMinNumberOfChars(this string input, int minNumOfLetters)
        {

            if (input.Length < minNumOfLetters)
            {
                Console.WriteLine("Password needs to have at least 5 chars!");

                return true;
            }

            return false;
        }

    }
}
