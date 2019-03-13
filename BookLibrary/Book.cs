using System.Collections.Generic;
using Contracts;

namespace BookLibrary
{
    public class Book : IBook
    {

        public string Title { get; private set; }

        public List<string> Authors { get; private set; }

        public string CoverURL { get; private set; }

        public string Description { get; private set; }

        public bool IsFavorite { get; set; }

        public string PreviewLink { get; private set; }

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

    }
}