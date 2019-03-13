using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public static class Helper
    {
        public static void Swap<T>(ref T o1, ref T o2)
        {
            T o1Copy = o1;
            o1 = o2;
            o2 = o1Copy;
        }

        public static void Swap<T>(T o1, T o2, out T outo1, out T outo2)
        {
            outo1 = o2;
            outo2 = o1;
        }

        //Erweiterungsmethoden
        public static void SwapExt<T>(this ref T obj, ref T obj2) where T : struct
        {
            T o1Copy = obj;
            obj = obj2;
            obj2 = o1Copy;
        }


        /// <summary>
        /// Fügt einem Dictionary, welches auf Collection-Typen mappt, einen neuen Datensatz hinzu
        /// </summary>
        /// <typeparam name="TKey">Datentyp des Keys</typeparam>
        /// <typeparam name="TValue">Datentyp des Values</typeparam>
        /// <typeparam name="TListItem">Datentyp der Objekte, die innerhalb von TValue verwaltet werden</typeparam>
        /// <param name="dict">Referenz auf das Dictionary</param>
        /// <param name="key">zu erstellender Key bzw. Key, zu dem ein Element hinzugefügt werden soll</param>
        /// <param name="value">hinzuzufügendes Element innerhalb der TValue-Liste</param>
        public static void AddOrCreate<TKey, TValue, TListItem>(this Dictionary<TKey, TValue> dict, TKey key, TListItem  value) where TValue : ICollection<TListItem>, new() 
        {
            //Füge den value zum vorhandenen Liste hinzu, wenn es schon einen Eintrag für den Key gibt
            //ansonste: lege neuen Key und neue Liste an, und füge value als den ersten Eintrag in der Liste ein
            if(dict.ContainsKey(key))
            {
                dict[key].Add(value);
            }
            else
            {
                TValue newList = new TValue();
                newList.Add(value);
                dict.Add(key, newList);
            }
        }


        public static int Quersumme(this int zahll)
        {
            string zahlAlsString = zahll.ToString();
            int summe = 0;
            foreach (char item in zahlAlsString)
            {
                summe += (int)item;
            }
            return summe;
        }
    }
}
