using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class FakeWebService : IWebService
    {
        public IEnumerable<IBook> SearchBooks(string searchTerm)
        {
            return new List<IBook>()
            {
                new Book(
                    "FakeBook1", 
                    new List<string>() {"FakeAutor1", "FakeAutor2" },
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/330px-Cat03.jpg",
                    "Fake Beschreibung",
                    "http://www.google.de",
                    "1234"),
                new Book(
                    "FakeBook2",
                    new List<string>() {"FakeAutor1", "FakeAutor2" },
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/330px-Cat03.jpg",
                    "Fake Beschreibung",
                    "http://www.google.de",
                    "5678")
            };
        }
    }
}