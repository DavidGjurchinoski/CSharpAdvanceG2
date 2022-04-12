using Entities;
using Services;

static void PrintUsers()
{
    UserDataBase.Users.ForEach(user => Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}"));
}

static void RegisterUser()
{

    Console.WriteLine("Enter First Name:");
    string firstName = Console.ReadLine();

    if (firstName.Length > User.MAX_INPUT_STRING)
    {
        Console.WriteLine($"Error name more then {User.MAX_INPUT_STRING}");

        return;
    }

    Console.WriteLine("Enter Last Name:");
    string lastName = Console.ReadLine();

    if (lastName.Length > User.MAX_INPUT_STRING)
    {
        Console.WriteLine($"Error last name more then {User.MAX_INPUT_STRING}");

        return;
    }

    UserDataBase.Users.Add(new User(firstName, lastName));
}

while(true)
{

    Console.WriteLine($"If you want to add user press {HelperInputs.ADD_USER}, press {HelperInputs.PRINT_INFO} to show all users");
    string userOption = Console.ReadLine();

    switch (userOption)
    {
        case HelperInputs.ADD_USER:
            RegisterUser();
            break;
        case HelperInputs.PRINT_INFO:
            PrintUsers();
            break;
        default:
            Console.WriteLine("invalid Input");
            break;
    }

}
