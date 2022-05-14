using Newtonsoft.Json;
using TaxiManager9000.DataAccess.Intervaces;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public abstract class FileDataBase<T> : IDatabase<T> where T : BaseEntity
    {
        protected List<T> Items;
        private readonly string _filePath;
        private int _currentId = 0;

        public FileDataBase()
        {
            _filePath = $@"{Directory.GetCurrentDirectory()}\{typeof(T).Name}.json";

            if (!File.Exists(_filePath))
            {
                var stream = File.Create(_filePath);
                stream.Close();
            }

            Task readFromFile = new(async () => { Items = await ReadFromFileAsync(); });
            readFromFile.Start();
            readFromFile.Wait();

            _currentId = Items.OrderBy(data => data.Id).LastOrDefault()?.Id ?? 0;
        }

        public async Task DeleteAsync(T Data)
        {
            Items.Remove(Data);

            await WriteToFileAsync(Items);
        }

        public List<T> GetAll()
        {
            return Items;
        }

        public T GetItemById(int Id)
        {
            return Items.FirstOrDefault(x => x.Id == Id);
        }

        public async Task InsertAsync(T Data)
        {
            AutoIncrementId(Data);

            Items.Add(Data);

            await WriteToFileAsync(Items);
        }

        public async Task UpdateAsync(T Data)
        {
            await WriteToFileAsync(Items);
        }

        private async Task WriteToFileAsync(List<T> Data)
        {
            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                await sw.WriteAsync(JsonConvert.SerializeObject(Data));
                sw.Close();
            }
        }

        async private Task<List<T>> ReadFromFileAsync()
        {
            string json;

            using (StreamReader sr = new StreamReader(_filePath))
            {
                json = await sr.ReadToEndAsync();
                sr.Close();
            }

            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        protected void AutoIncrementId(T item)
        {
            item.Id = ++_currentId;
        }
    }
}
