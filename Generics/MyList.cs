using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{

    public class MyList<InternalArrayType> : IEnumerable<InternalArrayType>
    {
        InternalArrayType[] _internalArray = new InternalArrayType[0];
        int _currentSize = 0;

        public void Add(InternalArrayType value)
        {
            InternalArrayType[] newArray = new InternalArrayType[_currentSize + 1];
            if(_currentSize > 0)
            {
                Array.Copy(_internalArray, newArray, _currentSize);
            }
            #region andere Array-Copy-Varianten
            //_internalArray.CopyTo(newArray, 0);
            //for (int i = 0; i < _internalArray.Length; i++)
            //{
            //    newArray[i] = _internalArray[i];
            //}
            #endregion

            newArray[_currentSize] = value;
            _currentSize++;
            _internalArray = newArray;

        }

        //für foreach
        public IEnumerator GetEnumerator()
        {
            //foreach (var item in _internalArray)
            //{
            //    yield return item;
            //}

            return _internalArray.GetEnumerator();
        }

        IEnumerator<InternalArrayType> IEnumerable<InternalArrayType>.GetEnumerator()
        {
            return (IEnumerator<InternalArrayType>)_internalArray.GetEnumerator();
        }

        //Indexer
        public InternalArrayType this[int index]
        {
            get
            {
                return _internalArray[index];
            }
            set
            {
                _internalArray[index] = value;
            }
        }
    }
}
