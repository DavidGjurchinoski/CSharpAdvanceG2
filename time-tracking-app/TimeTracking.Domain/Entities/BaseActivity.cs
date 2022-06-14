namespace TimeTracking.Domain.Entities
{
    public abstract class BaseActivity
    {
        protected BaseActivity(int id, TimeSpan duration)
        {
            Id = id;
            Duration = duration;
        }

        public int Id { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
