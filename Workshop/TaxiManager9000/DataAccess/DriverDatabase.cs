using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.DataAccess
{
    public class DriverDatabase : FileDataBase<Driver>, IDriverDatabase
    {

        public DriverDatabase() : base()
        {
            Task seedTask = new Task(() => Seed());
            seedTask.Start();
            seedTask.Wait();
        }

        private async Task Seed()
        {
            await InsertAsync(new Driver("Driver1", "LDriver1", Shift.Afternoon, "L1", new DateTime(2222, 1, 1)));
            await InsertAsync(new Driver("Driver2", "LDriver2", Shift.Evening, "L2", new DateTime(1992, 2, 12)));
            await InsertAsync(new Driver("Driver3", "LDriver3", Shift.Morning, "L3", new DateTime(1993, 3, 13)));
            await InsertAsync(new Driver("Driver4", "LDriver4", Shift.Afternoon, "L4", new DateTime(1994, 4, 14)));
            await InsertAsync(new Driver("Driver5", "LDriver5", Shift.Evening, "L5", new DateTime(1995, 5, 15)));
        }
    }
}
