using Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class RealStorage : IStorage
    {
        const string File_Name = "myFavorites.fbjson";
        JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        public IEnumerable<IBook> Load()
        {
            if(File.Exists(File_Name))
            {
                string json = File.ReadAllText(File_Name);
                return JsonConvert.DeserializeObject<List<IBook>>(json, _settings);
            }
            return new List<IBook>();
        }

        public bool Save(IEnumerable<IBook> books)
        {
            try
            {
                List<IBook> bookList = new List<IBook>(books);
                string json = JsonConvert.SerializeObject(bookList, _settings);
                File.WriteAllText(File_Name, json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
