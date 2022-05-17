using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;
namespace TaxiManager9000.DataAccess
{
    public abstract class Database<T> : IDatabase<T> where T : BaseEntity
    {
        protected List<T> _items;

        public Database()
        {
            _items = new List<T>();
        }
        public async Task UpdateAsync(T Data)
        {
            T foundItem = _items.FirstOrDefault(item => item.Id == Data.Id);

            int index = _items.IndexOf(Data);

            if (foundItem != null) _items[index] = Data;
        }

        public async Task<bool> DeleteAsync(T Data)
        {
            return _items.Remove(Data);
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public T GetItemById(int Id)
        {
            return _items.FirstOrDefault(item => item.Id == Id);
        }

        public async Task InsertAsync(T Data)
        {
            T itemToInsert = AutoIncrementId(Data);

            _items.Add(itemToInsert);
        }

        protected T AutoIncrementId(T item)
        {
            int currentId = 0;

            if (_items.Count > 0)
            {
                currentId = _items.OrderByDescending(x => x.Id).First().Id;
            }

            item.Id = ++currentId;

            return item;
        }
    }
}
