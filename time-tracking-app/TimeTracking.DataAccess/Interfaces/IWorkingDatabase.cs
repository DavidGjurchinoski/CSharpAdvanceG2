using TimeTracking.Domain.Entities;

namespace TimeTracking.DataAccess.Interfaces
{
    public interface IWorkingDatabase : IDatabase<WorkingActivity>, IActivityDatabase<WorkingActivity>
    {
    }
}
