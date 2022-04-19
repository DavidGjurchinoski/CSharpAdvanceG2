namespace TaxiManager9000.Shared.Utils
{
    public static class EnumUtils
    {
        public static void PrintAllEnumsWithNumbers(this Enum enumeration)
        {

            Type enumType = enumeration.GetType();
            Console.WriteLine(enumType.ToString());

            //foreach (int i in Enum.GetValues(enumType))
            //{
            //    Console.Write($"{i}. ");

            //    Console.WriteLine((enumType.GetType())i);
            //}
        }
    }
}
