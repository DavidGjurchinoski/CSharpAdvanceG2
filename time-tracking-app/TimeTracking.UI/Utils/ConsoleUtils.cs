namespace TimeTracking.UI.Utils
{
    public static class ConsoleUtils
    {
        public static void WriteInColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
