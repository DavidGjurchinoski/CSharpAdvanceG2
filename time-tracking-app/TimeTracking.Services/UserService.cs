using TimeTracking.Domain.Entities;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services
{
    public class UserService : IUserService<ReadingActivity>
    {
        public void AddActivity(ReadingActivity activity)
        {
            throw new NotImplementedException();
        }
    }
}
