using TimeTracking.Domain.Entities;

namespace TimeTracking.DataAccess.Interfaces
{
    public interface IDatabase<T>
    {
        Task InsertAsync(T Data);

        Task UpdateAsync(T Data);

        Task DeleteAsync(T Data);

        T GetById(int Id);

        List<T> GetAll();
    }
}
