using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Services.Services.Interfaces;
using TaxiManager9000.Shared;

namespace TaxiManager9000.Services.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IDriverDatabase _drivers;
        private readonly IVehiclesDatabase _vehicles;

        public ManagerService()
        {
            _drivers = DependencyResolver.GetService<IDriverDatabase>();
            _vehicles = DependencyResolver.GetService<IVehiclesDatabase>();
        }


        public List<Driver> GetAllDrivers()
        {
            return _drivers.GetAll();
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles.GetAll();
        }

        public void AssignDriver(Driver driver, Vehicle vehicle)
        {
            vehicle.AssignedDrivers.Add(driver);
        }

        public void UnAssignDriver(Driver driver, Vehicle vehicle)
        {
            vehicle.AssignedDrivers.Remove(driver);
        }
    }
}
