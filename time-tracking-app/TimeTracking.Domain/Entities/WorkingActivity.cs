using TimeTracking.Domain.Enums;

namespace TimeTracking.Domain.Entities
{
    public class WorkingActivity : BaseEntity
    {
        public WorkingActivity(int userId, int duration, Working type) : base()
        {
            UserId = userId;
            Duration = duration;
            Type = type;
        }

        public int UserId { get; set; }

        public int Duration { get; set; }

        public Working Type { get; set; }
    }
}
