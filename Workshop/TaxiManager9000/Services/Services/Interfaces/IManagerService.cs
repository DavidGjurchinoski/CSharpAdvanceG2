using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Services.Services.Interfaces
{
    public interface IManagerService
    {

        List<Driver> GetAllDrivers();

        List<Vehicle> GetAllVehicles();

        void AssignDriver(Driver driver, Vehicle vehicle, Shift shift);

        void UnAssignDriver(Driver driver);

        List<Vehicle> GetAllVehiclesThatAreFreeThatShift(Shift shift);

        Driver GetDriverById(int id);

        Vehicle GetVehicleById(int id);

        List<Driver> GetAllUnassignedDrivers();

        List<Driver> GetAllAssignedDrivers();

    }
}
