namespace TimeTracking.DataAccess.Interfaces
{
    public interface IActivityDatabase<T>
    {
        T GetActivityById(int id);

        List<T> GetActivityByUserId(int id);
    }
}
