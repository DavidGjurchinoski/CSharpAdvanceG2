List<DateTime> days = new List<DateTime>();
List<DateTime> restDays = new List<DateTime>()
{
    new DateTime(2020,1,1),
    new DateTime(2020,1,7),
    new DateTime(2020,4,20),
    new DateTime(2020,5,1),
    new DateTime(2020,5,25),
    new DateTime(2020,8,3),
    new DateTime(2020,9,8),
    new DateTime(2020,10,12),
    new DateTime(2020,10,23),
    new DateTime(2020,12,8)
};

days = EnterDays(days, restDays);
PrintWorkDays(days);

static List<DateTime> EnterDays(List<DateTime> days, List<DateTime> rest)
{
    try
    {
        string userInput = "";

        do
        {
            Console.WriteLine("Enter a date in the format 'MM,DD,YYYY'");

            string stringDay = Console.ReadLine();

            if (DateTime.TryParse(stringDay, out DateTime day))
            {
                if (rest.Where(restDay => day.Day == restDay.Day && day.Month == restDay.Month).ToList().Count == 0)
                {
                    if (day.DayOfWeek != DayOfWeek.Saturday || day.DayOfWeek != DayOfWeek.Sunday)
                    {
                        Console.WriteLine($"Date Added {day}");
                        days.Add(day);
                    }
                }

                do
                {
                    Console.WriteLine("Enter 'Yes' to enter another day or 'No' to close the app!");

                    userInput = Console.ReadLine().ToLower();

                    if (userInput == "yes") break;
                    if (userInput == "no") break;
                } while (true);
            }
            else
            {
                Console.WriteLine($"{stringDay} can not be converted to a date");
            }
        } while (userInput == "yes");

        return days;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        
        return days;
    }
}

static void PrintWorkDays(List<DateTime> days)
{
    days.ForEach(day => Console.WriteLine($"The date {day} is a working day!"));
}