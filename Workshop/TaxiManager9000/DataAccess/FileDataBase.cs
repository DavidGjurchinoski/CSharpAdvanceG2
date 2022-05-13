using Newtonsoft.Json;
using TaxiManager9000.DataAccess.Intervaces;

namespace TaxiManager9000.DataAccess
{
    public abstract class FileDataBase<T> : IDatabase<T>
    {

        public bool Delete(T Data)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return ReadFromFile();
        }

        public T GetItemById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T Data)
        {
            throw new NotImplementedException();
        }

        public void Update(T Data)
        {
            throw new NotImplementedException();
        }

        private string Serialize(T Data)
        {
            return JsonConvert.SerializeObject(Data);
        }

        private T Deserialize(string Data)
        {
            return JsonConvert.DeserializeObject<T>(Data);
        }

        private void WriteToFile(List<T> Data)
        {
            using(StreamWriter sw = new StreamWriter(""))
            {
                Data.ForEach(x => sw.WriteLine(Serialize(x)));
            }
        }

        private List<T> ReadFromFile()
        {
            List<T> dataList = new List<T>();

            using(StreamReader sr = new StreamReader(""))
            {
               while(!sr.EndOfStream)
                {
                    dataList.Add(Deserialize(sr.ReadLine()));
                }
            }

            return dataList;
        }
    }
}
