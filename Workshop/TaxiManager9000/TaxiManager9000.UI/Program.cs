using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Services;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Services.Services;
using TaxiManager9000.Services.Services.Interfaces;
using TaxiManager9000.Shared.Enums;
using TaxiManager9000.Shared.Helpers;
using TaxiManager9000.Shared.Services;
using TaxiManager9000.Shared.Utils;
using TaxiManager9000.UI.Utils;

IAuthService authService = new AuthService();
IAdminService adminService = new AdminService();
IMaintenanceService maintenanceService = new MaintenanceService();
IManagerService managerService = new ManagerService();

StartApplication(authService, adminService, maintenanceService);

Console.ReadLine();

void StartApplication(IAuthService authService, IAdminService adminService, IMaintenanceService maintenanceService)
{
    ShowLogin(authService);

    ShowMenu(authService, adminService, maintenanceService, managerService);

    StartApplication(authService, adminService, maintenanceService);
}

void ShowMenu(IAuthService authService, IAdminService adminService, IMaintenanceService maintenanceService, IManagerService managerService)
{
    switch (authService.CurrentUser.Role)
    {
        case Role.Administrator:
            ShowAdminMenu(adminService, authService);
            break;
        case Role.Maintainance:
            ShowMaintainenceMenu(authService, maintenanceService);
            break;
        case Role.Manager:
            ShowManagerMenu(authService, managerService);
            break;
        default:
            ConsoleUtils.WriteLineInColor($"Invalid role, {authService.CurrentUser.Role}", ConsoleColor.Red);
            break;
    }
}

void ShowAdminMenu(IAdminService adminService, IAuthService authService)
{
    Console.WriteLine("Input the number what do you want to do:");

    //foreach (int i in Enum.GetValues(typeof(AdminAction)))
    //{
    //    Console.Write($"{i}. ");

    //    Console.WriteLine((AdminAction)i);
    //}

    //Showing all the actions for ADMIN users PLUS the actions for all USERS
    for (int i = 1; i < Enum.GetNames(typeof(AdminAction)).Length + Enum.GetNames(typeof(UserAction)).Length + 1; i++)
    {
        // TO show the right ENUM Value and not go over the lenght
        if (Enum.GetNames(typeof(UserAction)).Length >= i)
        {
            Console.Write($"{i}. ");

            Console.WriteLine((UserAction)i);
        }
        else
        {
            Console.Write($"{i}. ");

            Console.WriteLine((AdminAction)i - Enum.GetNames(typeof(UserAction)).Length);
        }
    }

    string actionInput = Console.ReadLine();

    if (!int.TryParse(actionInput, out int actionInputInt))
    {
        ConsoleUtils.WriteLineInColor("Enter only numbers!", ConsoleColor.Red);

        ConsoleUtils.WriteLineInColor("Returning to Main Menu...", ConsoleColor.Yellow);

        ShowMenu(authService, adminService, maintenanceService, managerService);
    };

    // To select the right ACTION because the user sees the actions ID first of USER ACTIONS then the THE Other ACTIONS
    // EXAMPLE user sees 4 but in the enum is 1
    if (actionInputInt > Enum.GetNames(typeof(AdminAction)).Length)
    {
        actionInputInt -= Enum.GetNames(typeof(AdminAction)).Length;
    }

    switch (actionInput)
    {
        case InputHelper.CREATE_NEW_USER_ADMIN:
            ShowCreateNewUser(adminService);
            break;
        case InputHelper.DELETE_USER_ADMIN:
            ShowDeleteUser(adminService);
            break;
        case InputHelper.CHANGE_PASSWORD:
            ShowChangePassword(authService, adminService);
            break;
        case InputHelper.EXIT_APP:
            ExitApp();
            break;
        case InputHelper.LOG_OUT:
            LogOut(authService, adminService);
            break;
        default:
            ConsoleUtils.WriteLineInColor("Enter a number that you see", ConsoleColor.Red);
            StartApplication(authService, adminService, maintenanceService);
            break;
    }
}


void ShowMaintainenceMenu(IAuthService authService, IMaintenanceService maintenanceService)
{
    Console.WriteLine("Input the number what do you want to do:");

    //Showing all the actions for MAINTANENCE users PLUS the actions for all USERS
    for (int i = 1; i < Enum.GetNames(typeof(MaintenanceAction)).Length + Enum.GetNames(typeof(UserAction)).Length + 1; i++)
    {
        if (Enum.GetNames(typeof(UserAction)).Length >= i)
        {
            Console.Write($"{i}. ");

            // TO show the right ENUM Value and not go over the lenght
            Console.WriteLine((UserAction)i);
        }
        else
        {
            Console.Write($"{i}. ");

            Console.WriteLine((MaintenanceAction)i - Enum.GetNames(typeof(UserAction)).Length);
        }
    }

    string actionInput = Console.ReadLine();

    if (!int.TryParse(actionInput, out int actionInputInt))
    {
        ConsoleUtils.WriteLineInColor("Enter only numbers!", ConsoleColor.Red);

        ConsoleUtils.WriteLineInColor("Returning to Main Menu...", ConsoleColor.Yellow);

        ShowMenu(authService, adminService, maintenanceService, managerService);
    };

    // To select the right ACTION because the user sees the actions ID first of USER ACTIONS then the THE Other ACTIONS
    // EXAMPLE user sees 4 but in the enum is 1
    if (actionInputInt > Enum.GetNames(typeof(MaintenanceAction)).Length)
    {
        actionInputInt -= Enum.GetNames(typeof(MaintenanceAction)).Length;
    }

    switch (actionInput)
    {
        case InputHelper.SHOW_LICENSE_PLATES_STATUS_MAINTENANCE:
            ShowAllLicensePlatesStatus(maintenanceService);
            break;
        case InputHelper.SHOW_ALL_VEHICLES_MAINTENANCE:
            ShowAllVehicles(maintenanceService);
            break;
        case InputHelper.CHANGE_PASSWORD:
            ShowChangePassword(authService, adminService);
            break;
        case InputHelper.EXIT_APP:
            ExitApp();
            break;
        case InputHelper.LOG_OUT:
            LogOut(authService, adminService);
            break;
        default:
            ConsoleUtils.WriteLineInColor("Enter a number that you see", ConsoleColor.Red);
            StartApplication(authService, adminService, maintenanceService);
            break;
    }

    ShowMaintainenceMenu(authService, maintenanceService);
}


void ShowManagerMenu(IAuthService authService, IManagerService managerService)
{
    Console.WriteLine("Input the number what do you want to do:");

    //Showing all the actions for MANAGER users PLUS the actions for all USERS
    for (int i = 1; i < Enum.GetNames(typeof(ManagerAction)).Length + Enum.GetNames(typeof(UserAction)).Length + 1; i++)
    {
        // TO show the right ENUM Value and not go over the lenght
        if (Enum.GetNames(typeof(UserAction)).Length >= i)
        {
            Console.Write($"{i}. ");

            Console.WriteLine((UserAction)i);
        }
        else
        {
            Console.Write($"{i}. ");

            Console.WriteLine((ManagerAction)i - Enum.GetNames(typeof(UserAction)).Length);
        }
    }

    string actionInput = Console.ReadLine();

    if (!int.TryParse(actionInput, out int actionInputInt))
    {
        ConsoleUtils.WriteLineInColor("Enter only numbers!", ConsoleColor.Red);

        ConsoleUtils.WriteLineInColor("Returning to Main Menu...", ConsoleColor.Yellow);

        ShowMenu(authService, adminService, maintenanceService, managerService);
    };

    // To select the right ACTION because the user sees the actions ID first of USER ACTIONS then the THE Other ACTIONS
    // EXAMPLE user sees 4 but in the enum is 1
    if (actionInputInt > Enum.GetNames(typeof(ManagerAction)).Length)
    {
        actionInputInt -= Enum.GetNames(typeof(ManagerAction)).Length;
    }

    switch (actionInput)
    {
        case InputHelper.SHOW_ASSIGN_DRIVER_MANAGER:
            ShowAssignDrivers(maintenanceService);
            break;
        case InputHelper.SHOW_UNASSIGN_DRIVER_MANAGER:
            ShowUnAssignDrivers(managerService);
            break;
        case InputHelper.SHOW_TAXI_LICANCE_STATUS_MANAGER:
            ShowDriverLicenceStatus(managerService, authService);
            break;
        case InputHelper.SHOW_ALL_DRIVERS_MANAGER:
            ShowAllDrivers(managerService, authService);
            break;
        case InputHelper.CHANGE_PASSWORD:
            ShowChangePassword(authService, adminService);
            break;
        case InputHelper.EXIT_APP:
            ExitApp();
            break;
        case InputHelper.LOG_OUT:
            LogOut(authService, adminService);
            break;
        default:
            ConsoleUtils.WriteLineInColor("Enter a number that you see", ConsoleColor.Red);
            StartApplication(authService, adminService, maintenanceService);
            break;
    }
}

void ShowAllDrivers(IManagerService managerService, IAuthService authService)
{
    managerService.GetAllDrivers().ForEach(Console.WriteLine);

    ShowManagerMenu(authService, managerService);
}

void ShowDriverLicenceStatus(IManagerService managerService, IAuthService authService)
{
    managerService.GetAllDrivers().ForEach(driver =>
    {
        if (DateTime.Now.Subtract(driver.LicenseExpieryDate).Days < InputHelper.AVRG_DAYS_IN_3_MOUNTHS && DateTime.Now.Subtract(driver.LicenseExpieryDate).Days > 0)
        {
            ConsoleUtils.WriteLineInColor($"Status of Licence Plate: { driver.License }", ConsoleColor.Yellow);
        }
        else
        {
            ConsoleUtils.WriteLineInColor($"Status of Licence Plate: { driver.License }",
                                          DateTime.Compare(DateTime.Now, driver.LicenseExpieryDate) > 0 ? ConsoleColor.Red : ConsoleColor.Green);
        }
    });

    ShowManagerMenu(authService, managerService);
}

void ShowUnAssignDrivers(IManagerService managerService)
{
    Console.WriteLine("List of all assigned drivers:");
    managerService.GetAllAssignedDrivers().ForEach(driver => Console.WriteLine(driver.PrintForManager()));

    string pickedIdDriverString = Console.ReadLine();

    if (pickedIdDriverString.IsEmpty())
    {
        ConsoleUtils.WriteLineInColor("Please enter something!", ConsoleColor.Red);

        ShowManagerMenu(authService, managerService);
    }

    if (!int.TryParse(pickedIdDriverString, out int pickedIdDriverInt))
    {
        ConsoleUtils.WriteLineInColor("Please enter a number!", ConsoleColor.Red);

        ShowManagerMenu(authService, managerService);
    }

    if (!managerService.GetAllAssignedDrivers().Any(driver => driver.Id == pickedIdDriverInt))
    {
        ConsoleUtils.WriteLineInColor("Enter one of the given numbers!", ConsoleColor.Red);

        ShowManagerMenu(authService, managerService);
    }

    managerService.UnAssignDriver(managerService.GetDriverById(pickedIdDriverInt));

    ConsoleUtils.WriteLineInColor("Druver UnAssigned", ConsoleColor.Yellow);

    ShowMenu(authService, adminService, maintenanceService, managerService);
}

void ShowAssignDrivers(IMaintenanceService maintenanceService)
{
    Console.WriteLine("List of all unassigned drivers: (Pick by number)");
    managerService.GetAllUnassignedDrivers().ForEach(driver => Console.WriteLine(driver.PrintForManager()));

    string pickedIdDriverString = Console.ReadLine();

    if (pickedIdDriverString.IsEmpty())
    {
        ConsoleUtils.WriteLineInColor("Please enter something!", ConsoleColor.Red);

        ShowManagerMenu(authService, managerService);
    }

    if(!int.TryParse(pickedIdDriverString, out int pickedIdDriverInt))
    {
        ConsoleUtils.WriteLineInColor("Please enter a number!", ConsoleColor.Red);

        ShowManagerMenu(authService, managerService);
    }

    if(!managerService.GetAllUnassignedDrivers().Any(driver => driver.Id == pickedIdDriverInt))
    {
        ConsoleUtils.WriteLineInColor("Enter one of the given numbers!", ConsoleColor.Red);

        ShowManagerMenu(authService, managerService);
    }

    Driver pickedDriver = managerService.GetDriverById(pickedIdDriverInt);

    Console.WriteLine("Pick a shift from the given options!");
    foreach(int i in Enum.GetValues(typeof(Shift)))
    {
        Console.Write($"{i}. ");

        Console.WriteLine((Shift)i);
    }

    string pickedShiftString = Console.ReadLine();

    if (!Enum.TryParse(pickedShiftString, out Shift pickedShift))
    {
        ConsoleUtils.WriteLineInColor("Enter only numbers!", ConsoleColor.Red);

        ConsoleUtils.WriteLineInColor("Returning to Main Menu...", ConsoleColor.Yellow);

        ShowManagerMenu(authService, managerService);
    };

    Console.WriteLine("List of all cars that are free thet SHIFT: (Pick by number)");
    List<Vehicle> freeCars = managerService.GetAllVehiclesThatAreFreeThatShift(pickedShift);
    
    freeCars.ForEach(Console.WriteLine);

    string pickedIdVehicleString = Console.ReadLine();

    if (pickedIdDriverString.IsEmpty())
    {
        ConsoleUtils.WriteLineInColor("Please enter something!", ConsoleColor.Red);

        ShowManagerMenu(authService, managerService);
    }

    if (!int.TryParse(pickedIdVehicleString, out int pickedIdVehicleInt))
    {
        ConsoleUtils.WriteLineInColor("Please enter a number!", ConsoleColor.Red);

        ShowManagerMenu(authService, managerService);
    }

    if (!freeCars.Any(car => car.Id == pickedIdVehicleInt))
    {
        ConsoleUtils.WriteLineInColor("Enter one of the given numbers!", ConsoleColor.Red);

        ShowManagerMenu(authService, managerService);
    }

    Vehicle pickedVehicle = managerService.GetVehicleById(pickedIdVehicleInt);

    managerService.AssignDriver(pickedDriver, pickedVehicle, pickedShift);

    ConsoleUtils.WriteLineInColor("Driver Asigned", ConsoleColor.Green);

    ShowMenu(authService, adminService, maintenanceService, managerService);
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
            ConsoleUtils.WriteLineInColor("User Deleted", ConsoleColor.Red);

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

    StartApplication(authService, adminService, maintenanceService);
}

void ExitApp()
{
    ConsoleUtils.WriteLineInColor("Exeting APP...", ConsoleColor.Yellow);

    Environment.Exit(0);
}

void LogOut(IAuthService authService, IAdminService adminService)
{
    ConsoleUtils.WriteLineInColor("Logging Out...", ConsoleColor.Yellow);

    StartApplication(authService, adminService, maintenanceService);
}

void ShowAllLicensePlatesStatus(IMaintenanceService maintenanceService)
{
    maintenanceService.GetAllVehicles().ForEach(vehicle =>
    {
        if (DateTime.Now.Subtract(vehicle.LicensePlateExpieryDate).Days < InputHelper.AVRG_DAYS_IN_3_MOUNTHS && DateTime.Now.Subtract(vehicle.LicensePlateExpieryDate).Days > 0)
        {
            ConsoleUtils.WriteLineInColor($"Status of Licence Plate: { vehicle.LicensePlate }", ConsoleColor.Yellow);
        }
        else
        {
            ConsoleUtils.WriteLineInColor($"Status of Licence Plate: { vehicle.LicensePlate }",
                                          DateTime.Compare(DateTime.Now, vehicle.LicensePlateExpieryDate) > 0 ? ConsoleColor.Red : ConsoleColor.Green);
        }
    });
}

void ShowAllVehicles(IMaintenanceService maintenanceService)
{
    maintenanceService.GetAllVehicles().ForEach(Console.WriteLine);
}


