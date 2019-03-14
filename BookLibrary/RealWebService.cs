using Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class RealWebService : IWebService
    {
        public IEnumerable<IBook> SearchBooks(string searchTerm)
        {
            //TODO: Async optimieren und Exception Handling
            HttpClient client = new HttpClient();
            string json = client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={searchTerm}").Result;
            var result = JsonConvert.DeserializeObject<BookAPIResult>(json);
            List<IBook> books = new List<IBook>();
            foreach (var item in result.items)
            {
                string title = item.volumeInfo?.title;
                string desc = item.volumeInfo?.description;
                string id = item.id;
                List<string> authors = item.volumeInfo?.authors?.ToList() ?? new List<string>();
                string imageURL = item.volumeInfo?.imageLinks?.smallThumbnail;
                string previewLink = item.volumeInfo?.previewLink;

                IBook newBook = new Book(title, authors, imageURL, desc, previewLink, id);
                books.Add(newBook);
            }
            return books;
        }
    }
}
