using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class FavoriteManager
    {
        private Dictionary<string, IBook> _favoriteBooks;

        public Dictionary<string, IBook> FavoriteBooks
        {
            //Kopierkonstruktor
            get => new Dictionary<string, IBook>(_favoriteBooks);
            private set => _favoriteBooks = value;
        }

        public void MarkBooksAsFavorite(IEnumerable<IBook> book)
        {
            foreach (var item in book)
            {
                if (_favoriteBooks.ContainsKey(item.ID))
                {
                    item.IsFavorite = true;
                }
                else
                    item.IsFavorite = false;
            }

            //Kurzvariante mit Linq
            //book?.ToList().ForEach(b => b.IsFavorite = _favoriteBooks.ContainsKey(b.ID));
        }


        public FavoriteManager()
        {
            FavoriteBooks = new Dictionary<string, IBook>();
            var loadedFavorites = Globals.Storage.Load();
            if (loadedFavorites != null)
            {
                foreach (var item in loadedFavorites)
                {
                    item.IsFavorite = true;
                    _favoriteBooks.Add(item.ID, item);
                }
            }

            //Kurzvariante mit Linq
            //loadedFavorites?.ToList().ForEach(b => FavoriteBooks.Add(b.ID, b));
        }

        public bool AddAsFavoriteBook(IBook book, Action successCallback = null)
        {
            if (_favoriteBooks.ContainsKey(book.ID))
            {
                return false;
            }
            _favoriteBooks.Add(book.ID, book);
            book.IsFavorite = true;
            Globals.Storage.Save(FavoriteBooks.Values);
            successCallback?.Invoke();
            return true;
        }

        public bool RemoveFromFavoriteBooks(IBook book, Action successCallback = null)
        {
            if (!_favoriteBooks.ContainsKey(book.ID))
            {
                return false;
            }
            _favoriteBooks.Remove(book.ID);
            book.IsFavorite = false;
            Globals.Storage.Save(FavoriteBooks.Values);
            successCallback?.Invoke();
            return true;
        }

    }
}
