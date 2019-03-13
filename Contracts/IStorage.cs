using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStorage
    {
        bool Save(IEnumerable<IBook> books);
        IEnumerable<IBook> Load();
    }
}
