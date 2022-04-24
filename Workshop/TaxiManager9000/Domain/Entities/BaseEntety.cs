namespace TaxiManager9000.Domain.Entities
{
    public abstract class BaseEntety
    {
        public BaseEntety()
        {
            Id = -1;
        }

        //protected int Id { get; set; }
        public int Id { get; set; }


        //private Data AutoIncrementId(Data user)
        //{
        //}
    }
}
