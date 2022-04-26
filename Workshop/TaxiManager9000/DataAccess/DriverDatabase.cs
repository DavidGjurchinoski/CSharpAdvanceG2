using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.DataAccess
{
    public class DriverDatabase : IDriverDatabase
    {
        private readonly List<Driver> _drivers;

        public DriverDatabase()
        {
            _drivers = new List<Driver>();

            Seed();
        }

        public bool Delete(Driver Data)
        {
            return _drivers.Remove(Data);
        }

        public List<Driver> GetAll()
        {
            return _drivers;
        }

        public Driver GetItemById(int Id)
        {
            return _drivers.FirstOrDefault(driver => driver.Id == Id);
        }

        public void Insert(Driver car)
        {
            _drivers.Add(car);
        }

        private void Seed()
        {
            _drivers.AddRange(new List<Driver>()
            {
                new Driver("Driver1", "LDriver1", Shift.Afternoon, "L1", new DateTime(2222, 1, 1)),
                new Driver("Driver2", "LDriver2", Shift.Evening, "L2", new DateTime(1992, 2, 12)),
                new Driver("Driver3", "LDriver3", Shift.Morning, "L3", new DateTime(1993, 3, 13)),
                new Driver("Driver4", "LDriver4", Shift.Afternoon, "L4", new DateTime(1994, 4, 14)),
                new Driver("Driver5", "LDriver5", Shift.Evening, "L5", new DateTime(1995, 5, 15))
            });
        }
    }
}
