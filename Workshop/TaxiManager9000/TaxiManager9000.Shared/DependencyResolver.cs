using TaxiManager9000.DataAccess;
using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Shared.Intervaces;

namespace TaxiManager9000.Shared
{
    public static class DependencyResolver
    {

        private static Dictionary<Type, object> _dependencies = new Dictionary<Type, object>()
        {
            { typeof(IUserDatabase), new UserDatabase() },
            { typeof(IVehiclesDatabase), new CarDataBase() }

        };

        public static T GetService<T>()
        {
            return (T)_dependencies[typeof(T)];
        }

    }
}
