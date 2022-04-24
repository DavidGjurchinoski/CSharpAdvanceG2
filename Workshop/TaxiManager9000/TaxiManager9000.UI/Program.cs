using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Services;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Services.Services;
using TaxiManager9000.Services.Services.Interfaces;
using TaxiManager9000.Shared.Helpers;
using TaxiManager9000.Shared.Services;
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
            ShowAdminMenu(adminService, authService);
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

void ShowAdminMenu(IAdminService adminService, IAuthService authService)
{
    Console.WriteLine("Write the number what do you want to do:");

    foreach (int i in Enum.GetValues(typeof(AdminAction)))
    {
        Console.Write($"{i}. ");

        Console.WriteLine((AdminAction)i);
    }

    string adminActionInput = Console.ReadLine();

    switch (adminActionInput)
    {
        case InputHelper.CREATE_NEW_USER:
            ShowCreateNewUser(adminService);
            break;
        case InputHelper.DELETE_USER:
            ShowDeleteUser(adminService);
            break;
        case InputHelper.CHANGE_PASSWORD:
            ShowChangePassword(authService, adminService);
            break;
        case InputHelper.EXIT_APP:
            ExitApp();
            break;
        case InputHelper.LOG_OUT:
            LogOut(authService,adminService);
            break;
        default:
            Console.WriteLine("Invalid Input!");
            ShowLogin(authService);
            break;
    }
}

void ExitApp()
{
    ConsoleUtils.WriteLineInColor("Exeting APP...", ConsoleColor.Yellow);

    Environment.Exit(0);
}

void LogOut(IAuthService authService, IAdminService adminService)
{
    ConsoleUtils.WriteLineInColor("Logging Out...", ConsoleColor.Yellow);

    StartApplication(authService, adminService);
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

            if (adminService.CreateNewUser(username, password, role)) ConsoleUtils
                            .WriteLineInColor($"Successful creation of an {role} user!", ConsoleColor.Green);

            adminService.GetAllUsers().ForEach(Console.WriteLine);


        }
        catch (UserNotCreatedExeption ex)
        {
            Console.WriteLine(ex);
        }

        ShowAdminMenu(adminService, authService);

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

            ShowAdminMenu(adminService, authService);
        }
        else
        {
            Console.WriteLine("Entered number is not valid!");
        }
    }
    else
    {
        Console.WriteLine("Invalid Input");
    };

}

void ShowChangePassword(IAuthService authService, IAdminService adminService)
{
    Console.WriteLine("Enter old password:");
    
    string oldPassword = Console.ReadLine();

    if (authService.CurrentUser.Password != oldPassword)
    {
        ConsoleUtils.WriteLineInColor("Incorrect Password Try again!", ConsoleColor.Red);

        return;
    }

    Console.WriteLine("Enter a new password:");

    string newPassword = Console.ReadLine();

    if (ValidateInput.CheckPassword(newPassword))
    {
        authService.CurrentUser.ChangePassword(newPassword);

        ConsoleUtils.WriteLineInColor("Password has been changed.", ConsoleColor.Green);
    }
    else
    {
        ConsoleUtils.WriteLineInColor("Invalid input! Try again.", ConsoleColor.Red);
    }

    StartApplication(authService, adminService);
}