using TimeTracking.Domain.Enums;

namespace TimeTracking.Domain.Entities
{
    public class ReadingActivity : BaseEntity
    {
        public ReadingActivity(int userId, int duration, int pageCount, ReadingType type) : base()
        {
            PageCount = pageCount;
            Type = type;
            Duration = duration;
            UserId = userId;
        }
        public int UserId { get; set; }

        public int PageCount { get; set; }

        public ReadingType Type { get; set; }

        public int Duration { get; set; }
    }
}
