using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;

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
                //new Driver("FirstDriver1", "LastDriver1", Shift.Afternoon, new Car("Camaro", "TT11111", new DateTime(1991, 1, 11))),
                //new Driver("Camry", "TT22222", new DateTime(1992, 2, 12)),
                //new Driver("Camry Hybrid", "TT33333", new DateTime(1993, 3, 13)),
                //new Driver("Camaro", "TT44444", new DateTime(1994, 4, 14)),
                //new Driver("A4", "TT555555", new DateTime(1995, 5, 15)),

            });
        }
    }
}
