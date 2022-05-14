using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class VehiclesDataBase : FileDataBase<Vehicle>, IVehiclesDatabase
    {

        public VehiclesDataBase() : base()
        {
            Task seedTask = (new Task(() => Seed()));
            seedTask.Start();
            seedTask.Wait();
        }

        private async void Seed()
        {
                await InsertAsync(new Vehicle("Camry", "TT22222", new DateTime(2222, 2, 12)));
                await InsertAsync(new Vehicle("Camaro", "TT11111", new DateTime(1991, 1, 11)));
                await InsertAsync(new Vehicle("Camry Hybrid", "TT33333", new DateTime(2022, 4, 20)));
                await InsertAsync(new Vehicle("Camaro", "TT44444", new DateTime(1994, 4, 14)));
                await InsertAsync(new Vehicle("A4", "TT555555", new DateTime(3333, 5, 15)));
        }

        private void Update()
        {

        }
    }
}
