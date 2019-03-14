using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBookPresenterPlugin
    {
        /// <summary>
        /// Erweitert das BookPresenter-UserControl
        /// </summary>
        /// <param name="book">Das darzustellende Buch</param>
        /// <param name="panel">Das zu erweiternde StackPanel</param>
        void ExtendBookPresenter(IBook book, object panel);
    }
}
