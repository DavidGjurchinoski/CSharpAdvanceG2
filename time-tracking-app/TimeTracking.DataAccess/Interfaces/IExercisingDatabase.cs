using TimeTracking.Domain.Entities;

namespace TimeTracking.DataAccess.Interfaces
{
    public interface IExercisingDatabase : IDatabase<ExercisingActivity>, IActivityDatabase<ExercisingActivity>
    {

    }
}
