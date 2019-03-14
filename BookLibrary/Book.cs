using System.Collections.Generic;
using Contracts;

namespace BookLibrary
{
    public class Book : IBook
    {
        [SortButtonTitle("Titel")]
        public string Title { get; private set; }


        [SortButtonTitle("Autoren")]
        public List<string> Authors { get; private set; }

        [SortButtonTitle("Cover")]
        public string CoverURL { get; private set; }

        [SortButtonTitle("Beschreibung")]
        public string Description { get; private set; }

        [SortButtonTitle("Favorit")]
        public bool IsFavorite { get; set; }

        [Invisible]
        public string PreviewLink { get; private set; }

        [Invisible]
        public string ID { get; private set; }

        public Book(string title, List<string> authors, string coverURL, string description, string previewLink, string id, bool isFavorite = false)
        {
            Title = title;
            Authors = authors;
            CoverURL = coverURL;
            Description = description;
            IsFavorite = isFavorite;
            PreviewLink = previewLink;
            ID = id;
        }

        //public Book(IBook book ) : this(book.Title, book.Authors)
        //{

        //}

    }
}