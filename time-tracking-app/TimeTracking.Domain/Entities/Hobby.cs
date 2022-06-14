namespace TimeTracking.Domain.Entities
{
    public class Hobby : BaseEntity
    {
        public Hobby(int userId, int duration, string name) : base()
        {
            UserId = userId;
            Duration = duration;
            Name = name;
        }

        public int UserId { get; set; }

        public int Duration { get; set; }

        public string Name { get; set; }
    }
}
