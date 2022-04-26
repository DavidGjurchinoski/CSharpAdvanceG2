using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class VehiclesDataBase : Database<Vehicle>, IVehiclesDatabase
    {

        public VehiclesDataBase() : base()
        {
            Seed();
        }

        private void Seed()
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Vehicle("Camry", "TT22222", new DateTime(2222, 2, 12)),
                new Vehicle("Camaro", "TT11111", new DateTime(1991, 1, 11)),
                new Vehicle("Camry Hybrid", "TT33333", new DateTime(2022, 4, 20)),
                new Vehicle("Camaro", "TT44444", new DateTime(1994, 4, 14)),
                new Vehicle("A4", "TT555555", new DateTime(3333, 5, 15))
            };

            vehicles.ForEach(x => Insert(x));
        }

        private void Update()
        {

        }
    }
}
