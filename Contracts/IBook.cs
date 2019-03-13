using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBook
    {
        string ID { get; }
        string Title { get; }
        List<string> Authors { get; }
        string CoverURL { get; }
        string Description { get; }
        bool IsFavorite { get; set; }
        string PreviewLink { get; }
    }
}
