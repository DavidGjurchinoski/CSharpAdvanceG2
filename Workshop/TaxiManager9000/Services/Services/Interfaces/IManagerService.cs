using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.Services.Services.Interfaces
{
    public interface IManagerService
    {

        List<Driver> GetAllDrivers();

        List<Vehicle> GetAllVehicles();

        void AssignDriver(Driver driver, Vehicle vehicle);

        void UnAssignDriver(Driver driver, Vehicle vehicle);

    }
}
