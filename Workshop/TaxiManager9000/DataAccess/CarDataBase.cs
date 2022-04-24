using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Shared.Intervaces;

namespace TaxiManager9000.DataAccess
{
    public class CarDataBase : IVehiclesDatabase
    {

        private readonly List<Car> _cars;

        public CarDataBase()
        {
            _cars = new List<Car>();

            Seed();

            _cars.ForEach(car => AutoIncrementId(car));
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Insert(Car car)
        {
            _cars.Add(car);
        }

        private void Seed()
        {
            //_cars.AddRange(new List<Driver>()
            //{
            //    new Car("Camaro", "TT11111", new DateTime(1991, 1, 11), new Driver()),
            //    new Car("Camry", "TT22222", new DateTime(1992, 2, 12), new Driver()),
            //    new Car("Camry Hybrid", "TT33333", new DateTime(1993, 3, 13), new Driver()),
            //    new Car("Camaro", "TT44444", new DateTime(1994, 4, 14), new Driver()),
            //    new Car("A4", "TT555555", new DateTime(1995, 5, 15), new Driver()),

            //});
        }

        private Car AutoIncrementId(Car car)
        {
            int currentId = 0;

            if (_cars.Count > 0)
            {
                currentId = _cars.OrderByDescending(x => x.Id).First().Id;
            }

            car.Id = ++currentId;

            return car;
        }

        public bool Delete(Car Data)
        {
            return _cars.Remove(Data);
        }

        public Car GetItemById(int Id)
        {
            return _cars.FirstOrDefault(car => car.Id == Id);
        }
    }
}
