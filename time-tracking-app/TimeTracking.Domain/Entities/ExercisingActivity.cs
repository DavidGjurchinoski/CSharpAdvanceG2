using TimeTracking.Domain.Enums;

namespace TimeTracking.Domain.Entities
{
    public class ExercisingActivity : BaseEntity
    {
        public ExercisingActivity(int userId, int duration, ExercisingType type) : base()
        {
            UserId = userId;
            Duration = duration;
            Type = type;
        }

        public int UserId { get; set; }

        public int Duration { get; set; }

        public ExercisingType Type { get; set; }
    }
}
