namespace TimeTracking.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = -1;
        }

        public BaseEntity(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
