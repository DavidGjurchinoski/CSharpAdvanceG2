using TimeTracking.Domain.Entities;

namespace TimeTracking.DataAccess.Interfaces
{
    public interface IReadingDatabase : IDatabase<ReadingActivity>, IActivityDatabase<ReadingActivity>
    {

    }
}
