using System.Collections.Generic;
using Contracts;

namespace BookLibrary
{
    public class FakeStorage : IStorage
    {
        public IEnumerable<IBook> Load()
        {
            return new List<IBook>()
            {
                new Book(
                    "FavoriteBook1",
                    new List<string>() {"FakeAutor1", "FakeAutor2" },
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/330px-Cat03.jpg",
                    "Fake Beschreibung",
                    "http://www.google.de",
                    "12"),
                new Book(
                    "FavoriteBook2",
                    new List<string>() {"FakeAutor1", "FakeAutor2" },
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/330px-Cat03.jpg",
                    "Fake Beschreibung",
                    "http://www.google.de",
                    "14")
            };
        }

        public bool Save(IEnumerable<IBook> books)
        {
            return true;
        }
    }
}