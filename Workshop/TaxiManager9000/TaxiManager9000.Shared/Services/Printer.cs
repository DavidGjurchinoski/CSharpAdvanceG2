using TaxiManager9000.Shared.Enums;

namespace TaxiManager9000.Shared.Services
{
    public static class Printer
    {
        /*
        public static void PrintActions(Enum inputedEnum)
        {
            Type enumType = inputedEnum.GetType();

            //Showing all the actions for ADMIN users PLUS the actions for all USERS
            for (int i = 1; i < Enum.GetNames(typeof(inputedEnum)).Length + Enum.GetNames(typeof(UserAction)).Length + 1; i++)
            {
                if (Enum.GetNames(typeof(AdminAction)).Length >= i)
                {
                    Console.Write($"{i}. ");

                    Console.WriteLine((AdminAction)i);
                }
                else
                {
                    Console.Write($"{i}. ");

                    // TO show the right ENUM Value and not go over the lenght
                    Console.WriteLine((UserAction)i - Enum.GetNames(typeof(AdminAction)).Length);
                }
            }
        }
        */
    }
}
