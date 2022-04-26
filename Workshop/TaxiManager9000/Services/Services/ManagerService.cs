using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
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

        public void AssignDriver(Driver driver, Vehicle vehicle, Shift shift)
        {
            vehicle.AssignedDrivers.Add(driver);

            driver.Car = vehicle;

            driver.Shift = shift;
        }

        public void UnAssignDriver(Driver driver)
        {
            driver.Car.AssignedDrivers.Remove(driver);

            driver.Car = null;
        }

        public List<Vehicle> GetAllVehiclesThatAreFreeThatShift(Shift shift)
        {
            return _vehicles.GetAll().Where(vehicle => vehicle.AssignedDrivers.All(driver => driver.Shift != shift)).ToList();
        }

        public List<Driver> GetAllUnassignedDrivers()
        {
            return GetAllDrivers().Where(driver => driver.Car == null).ToList();
        }

        public List<Driver> GetAllAssignedDrivers()
        {
            return GetAllDrivers().Where(driver => driver.Car != null).ToList();
        }

        public Driver GetDriverById(int id)
        {
            return _drivers.GetItemById(id);
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicles.GetItemById(id);
        }

    }
}
