List<string> listOfNames = new List<string>();

EnterNames(listOfNames);


static void EnterNames(List<string> listOfNames)
{
    string input;
    do
    {

        Console.WriteLine("Enter a name:");

        input = Console.ReadLine(); 

    }
    while (input.ToLower() != "x");

    Console.WriteLine("Enter something to be searched in the list of names:");
    string searchText = Console.ReadLine();
    int counter = 0;

    listOfNames
    .Where(name => name.ToLower() == searchText.ToLower())
    .ToList()
    .ForEach(name => counter++);

    Console.WriteLine($"The name {searchText} is found: {counter} times");
}