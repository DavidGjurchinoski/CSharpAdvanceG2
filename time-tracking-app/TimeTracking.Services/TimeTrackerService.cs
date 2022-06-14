using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services
{
    public class TimeTrackerService : ITimerTrackerService
    {
        System.Timers.Timer timer = new(interval: 1000);

        private int seconds = 0;

        public void StartTimer()
        {
            seconds = 0;

            timer.Elapsed += (sender, e) => 
            {
                SetAndClear();
                HandleTimer();
            };

            timer.Start();
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        private void HandleTimer()
        {
            seconds += 1;
            Console.WriteLine(seconds.ToString());
        }

        public string GetTimeInMinutes()
        {
            return  TimeSpan.FromSeconds(seconds).ToString() + " seconds";
        }

        private void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private void SetAndClear()
        {
            if (seconds >= 1)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
        }
    }
}
