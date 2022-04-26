using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Services.Services.Interfaces;
using TaxiManager9000.Shared;

namespace TaxiManager9000.Services.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IVehiclesDatabase _vehicles;

        public MaintenanceService()
        {
            _vehicles = DependencyResolver.GetService<IVehiclesDatabase>();
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles.GetAll();
        }
    }
}
