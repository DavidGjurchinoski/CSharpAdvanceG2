using TimeTracking.Domain.Entities;

namespace TimeTracking.DataAccess.Interfaces
{
    public interface IHobbyDatabase : IDatabase<Hobby>, IActivityDatabase<Hobby>
    {
    }
}
