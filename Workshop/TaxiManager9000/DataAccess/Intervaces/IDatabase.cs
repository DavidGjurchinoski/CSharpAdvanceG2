namespace TaxiManager9000.DataAccess.Intervaces
{
    public interface IDatabase<T>
    {

        Task InsertAsync(T Data);

        Task UpdateAsync(T Data);

        List<T> GetAll();

        Task DeleteAsync(T Data);

        T GetItemById(int Id);

    }
}
