using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Services;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Services.Services;
using TaxiManager9000.Services.Services.Interfaces;
using TaxiManager9000.UI.Utils;

IAuthService authService = new AuthService();
IAdminService adminService = new AdminService();

StartApplication(authService, adminService);

Console.ReadLine();

void StartApplication(IAuthService authService, IAdminService adminService)
{
    ShowLogin(authService);

    ShowMenu(authService, adminService);
}

void ShowMenu(IAuthService authService, IAdminService adminService)
{
    switch (authService.CurrentUser.Role)
    {
        case Role.Administrator:
            ShowAdminMenu(adminService);
            break;
        case Role.Maintainance:
            ShowMaintainenceMenu(authService);
            break;
        case Role.Manager:
            ShowManagerMenu(authService);
            break;
        default:
            ConsoleUtils.WriteLineInColor($"Invalid role, {authService.CurrentUser.Role}", ConsoleColor.Red);
            break;
    }
}

void ShowAdminMenu(IAdminService adminService)
{
    Console.WriteLine("Write the number what do you want to do:");

    //ShowCreateNewUser(adminService);

    ShowDeleteUser(adminService);

}

void ShowMaintainenceMenu(IAuthService authService)
{
    throw new NotImplementedException();
}

void ShowManagerMenu(IAuthService authService)
{
    throw new NotImplementedException();
}

void ShowLogin(IAuthService authService)
{
    Console.WriteLine("Enter username");
    string username = Console.ReadLine();

    Console.WriteLine("Enter password");
    string password = Console.ReadLine();

    User currentUser;
    try
    {
        authService.LogIn(username, password);

        ConsoleUtils.WriteLineInColor($"Successful login! Welcome {authService.CurrentUser.Role} {authService.CurrentUser.UserName}",
                                      ConsoleColor.Green);
    }
    catch (InvalidCredentialsException ex)
    {
        ConsoleUtils.WriteLineInColor("Unsuccessful login, try again", ConsoleColor.Red);
    }
}

void ShowCreateNewUser(IAdminService adminService)
{
    Console.WriteLine("Creating a new user");

    Console.WriteLine("Enter username");
    string username = Console.ReadLine();

    Console.WriteLine("Enter password");
    string password = Console.ReadLine();

    Console.WriteLine("Choose one of the roles by number");

    foreach (int i in Enum.GetValues(typeof(Role)))
    {
        Console.Write($"{i}. ");

        Console.WriteLine((Role)i);
    }

    string roleString = Console.ReadLine();

    if (Enum.TryParse(roleString, out Role role))
    {
        try
        {

            if (adminService.CreateNewUser(new User(username, password, role))) ConsoleUtils
                            .WriteLineInColor($"Successful creation of an {role} user!", ConsoleColor.Green);

            adminService.GetAllUsers().ForEach(Console.WriteLine);

        }
        catch (UserNotCreatedExeption ex)
        {
            Console.WriteLine(ex);
        }
    }
    else Console.WriteLine("Enter one of the shown numbers!");
}

void ShowDeleteUser(IAdminService adminService)
{
    adminService.GetAllUsers().ForEach(Console.WriteLine);

    Console.WriteLine("Choose a user by id to delete");

    string userId = Console.ReadLine();

    if (int.TryParse(userId, out int userIdInt))
    {
        if (adminService.DeleteUser(userIdInt))
        {
            Console.WriteLine("User Deleted");

            ShowAdminMenu(adminService);
        } else
        {
            Console.WriteLine("Entered number is not valid!");
        }
    }
    else
    {
        Console.WriteLine("Invalid Input");
    };

}