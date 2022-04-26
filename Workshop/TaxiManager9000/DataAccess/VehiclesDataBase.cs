using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class VehiclesDataBase : IVehiclesDatabase
    {

        private readonly List<Vehicle> _cars;

        public VehiclesDataBase()
        {
            _cars = new List<Vehicle>();

            Seed();

            _cars.ForEach(car => AutoIncrementId(car));
        }

        public List<Vehicle> GetAll()
        {
            return _cars;
        }

        public void Insert(Vehicle car)
        {
            _cars.Add(car);
        }

        private void Seed()
        {
            _cars.AddRange(new List<Vehicle>()
            {
                new Vehicle("Camry", "TT22222", new DateTime(2222, 2, 12)),
                new Vehicle("Camaro", "TT11111", new DateTime(1991, 1, 11)),
                new Vehicle("Camry Hybrid", "TT33333", new DateTime(2022, 4, 20)),
                new Vehicle("Camaro", "TT44444", new DateTime(1994, 4, 14)),
                new Vehicle("A4", "TT555555", new DateTime(3333, 5, 15))
            });
        }

        private Vehicle AutoIncrementId(Vehicle car)
        {
            int currentId = 0;

            if (_cars.Count > 0)
            {
                currentId = _cars.OrderByDescending(x => x.Id).First().Id;
            }

            car.Id = ++currentId;

            return car;
        }

        public bool Delete(Vehicle Data)
        {
            return _cars.Remove(Data);
        }

        public Vehicle GetItemById(int Id)
        {
            return _cars.FirstOrDefault(car => car.Id == Id);
        }
    }
}
