using TimeTracking.Domain.Enums;
using TimeTracking.Services;
using TimeTracking.Services.Interfaces;
using TimeTracking.UI.Helpers;
using TimeTracking.UI.Utils;

IAuthService authService = new AuthService();
ITimerTrackerService timerService = new TimeTrackerService();

StartAppAsync();

async void StartAppAsync()
{
    ConsoleUtils.WriteInColor("Welcome to Time Tracking APP", ConsoleColor.Green);

    if(authService.CurrentUser == null)
    {
        ShowAuthMenu(authService);
    } else
    {
        ShowMainMenu(authService);
    }


}

void ShowMainMenu(IAuthService authService)
{
    Console.WriteLine($"{UserOptions.LOG_OUT}.Log Out\n{UserOptions.TRACK}.Track");
    string actionChoise = Console.ReadLine();

    switch(actionChoise)
    {
        case UserOptions.LOG_OUT:
            ConsoleUtils.WriteInColor("Loging Out... Byee!", ConsoleColor.Yellow);
            authService.LogOut();
            StartAppAsync();
            break;
        case UserOptions.TRACK:
            ShowTrack(authService);
            StartAppAsync();
            break;
        default:
            ConsoleUtils.WriteInColor("Invalid Input! Please enter one of the given options...", ConsoleColor.Red);
            ShowMainMenu(authService);
            break;
    }
}

void ShowTrack(IAuthService authService)
{
    ConsoleUtils.WriteInColor(
        $"{TrackOptions.READING}.Reading\n" +
        $"{TrackOptions.EXERCISING}.Exercising\n" +
        $"{TrackOptions.WORKING}.Working\n" +
        $"{TrackOptions.OTHER_HOBBY}.Other Hobby"
        , ConsoleColor.Cyan);
    string trackChosen = Console.ReadLine();

    switch(trackChosen)
    {
        case TrackOptions.READING:
            ShowReadingActivity(authService, timerService);
            break;
        case TrackOptions.EXERCISING:
            ShowExercisingActivity(authService);
            break;
        case TrackOptions.WORKING:
            ShowWorkingActivity(authService);
            break;
        case TrackOptions.OTHER_HOBBY:
            ShowHobbyActivity(authService);
            break;
        default:
            ConsoleUtils.WriteInColor("Invalid Input! Please enter one of the given options...", ConsoleColor.Red);
            ShowMainMenu(authService);
            break;
    }
}

void ShowHobbyActivity(IAuthService authService)
{
    throw new NotImplementedException();
}

void ShowWorkingActivity(IAuthService authService)
{
    throw new NotImplementedException();
}

void ShowExercisingActivity(IAuthService authService)
{
    throw new NotImplementedException();
}

void ShowReadingActivity(IAuthService authService, ITimerTrackerService timerService)
{
    ConsoleUtils.WriteInColor("Timer is started", ConsoleColor.Green);
    timerService.StartTimer();

    ConsoleUtils.WriteInColor("PressEnter when you want to stop the timer", ConsoleColor.Cyan);

    Console.ReadLine();

    timerService.StopTimer();

    ConsoleUtils.WriteInColor("Enter the number of pages:", ConsoleColor.Cyan);
    int.TryParse(Console.ReadLine(), out int pagesCount);

    ConsoleUtils.WriteInColor("Enter the type of book:", ConsoleColor.Cyan);
    Console.WriteLine
        (
            $"{ReadingType.Fiction}.Fiction\n" +
            $"{ReadingType.ProfessionalLiterature}.Professional Literature\n" +
            $"{ReadingType.BellesLettres}.Belles Lettres"
        );
    string type = Console.ReadLine();

    
}

void ShowAuthMenu(IAuthService authService)
{
    Console.WriteLine($"{AuthOptions.LOG_IN}.Log In\n{AuthOptions.REGISTER_USER}.Register");
    string authChoice = Console.ReadLine();

    switch (authChoice)
    {
        case AuthOptions.LOG_IN:
            ShowLogIn(authService);
            break;
        case AuthOptions.REGISTER_USER:
            ShowRegister(authService);
            break;
        default:
            ConsoleUtils.WriteInColor("Invalid Input! Please enter one of the given options...", ConsoleColor.Red);
            ShowAuthMenu(authService);
            break;
    }

}

void ShowRegister(IAuthService authService)
{
    ConsoleUtils.WriteInColor("Enter your First Name:", ConsoleColor.Cyan);
    string firstName = Console.ReadLine();

    ConsoleUtils.WriteInColor("Enter your Last Name:", ConsoleColor.Cyan);
    string lastName = Console.ReadLine();

    ConsoleUtils.WriteInColor("Enter your age:", ConsoleColor.Cyan);
    string age = Console.ReadLine();

    ConsoleUtils.WriteInColor("Enter username:", ConsoleColor.Cyan);
    string username = Console.ReadLine();

    ConsoleUtils.WriteInColor("Enter password:", ConsoleColor.Cyan);
    string password = Console.ReadLine();

    if(!int.TryParse(age, out int intAge))
    {
        ConsoleUtils.WriteInColor("Enter a valid Age!", ConsoleColor.Red);
        StartAppAsync();
    } else {
        try
        {
            authService.Register(firstName, lastName, intAge, username, password);
        }
        catch (Exception ex)
        {
            ConsoleUtils.WriteInColor(ex.Message, ConsoleColor.Red);
            StartAppAsync();
        }
    }

}

void ShowLogIn(IAuthService authService)
{
    for(int i = 0; i < 3; i++)
    {
        ConsoleUtils.WriteInColor("Enter your username:", ConsoleColor.Cyan);
        string username = Console.ReadLine();

        ConsoleUtils.WriteInColor("Enter your password:", ConsoleColor.Cyan);
        string password = Console.ReadLine();

        try
        {
            authService.LogIn(username, password);

            ConsoleUtils.WriteInColor($"Success! Welcome {authService.CurrentUser.FirstName}.", ConsoleColor.Green);

            StartAppAsync();
        }
        catch (Exception ex)
        {
            ConsoleUtils.WriteInColor(ex.Message, ConsoleColor.Red);

            ConsoleUtils.WriteInColor("Unsuccessful login! Try again...", ConsoleColor.Red);
        }
    }

    ConsoleUtils.WriteInColor("Surpassed tries...\nClosing APP...\nGoodbye...", ConsoleColor.Red);
    Environment.Exit(0);
}
