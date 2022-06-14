namespace TimeTracking.Services.Interfaces
{
    public interface IUserService<T>
    {
        void AddActivity(T activity);
    }
}
