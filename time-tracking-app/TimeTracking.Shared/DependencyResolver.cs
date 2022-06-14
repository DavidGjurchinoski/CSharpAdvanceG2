using TimeTracking.DataAccess;
using TimeTracking.DataAccess.Interfaces;

namespace TimeTracking.Shared
{
    public static class DependencyResolver
    {
        private static Dictionary<Type, object> _dependencies = new Dictionary<Type, object>()
        {
            { typeof(IUserDatabase), new UserDatabase() },
            { typeof(IReadingDatabase), new ReadingDatabase() },
            { typeof(IExercisingDatabase), new ExercisingDatabase() },
            { typeof(IWorkingDatabase), new WorkingDatabase() },
        };

        public static T GetServices<T>()
        {
            return (T)_dependencies[typeof(T)];
        }
    }
}