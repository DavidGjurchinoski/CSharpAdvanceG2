namespace TaxiManager9000.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = -1;
        }

        public int Id { get; set; }


    }
}
