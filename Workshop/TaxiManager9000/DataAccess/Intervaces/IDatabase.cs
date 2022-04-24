namespace TaxiManager9000.DataAccess.Intervaces
{
    public interface IDatabase<T>
    {

        void Insert(T Data);

        List<T> GetAll();

        bool Delete(T Data);

        T GetItemById(int Id);

    }
}
