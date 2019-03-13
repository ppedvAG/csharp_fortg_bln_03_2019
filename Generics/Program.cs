using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MyListTest();

            //GenericsBeispiele();

            //GenerischeMethoden();

            //GenerischeDictionaryMethode();

            Linq();

            Console.ReadKey();
        }

        private static void Linq()
        {
            List<Mensch> menschen = new List<Mensch>()
            {
                new Mensch("Anton", 20),
                new Mensch("Sandra", 11),
                new Mensch("Olaf", 4),
            };

            Filtern(menschen, Volljährig);
            Filtern(menschen, FängtMitAAn);
            Filtern(menschen, (Mensch mensch) =>
            {
                return mensch.Alter >= 18;
            });

            Filtern(menschen, (Mensch mensch) => mensch.Alter >= 18);
            Filtern(menschen, mensch => mensch.Alter >= 18);
            Filtern(menschen, m => m.Alter > 18 || m.Name[0] == 'A');

            menschen.Where(m => m.Alter < 18);
            //Aufsteigend nach Namen
            menschen.OrderBy(m => m.Name);
            //Absteigend nach Namen 
            menschen =  menschen.OrderByDescending(m => m.Name).ToList();

            var menschMit20Jahren = menschen.SingleOrDefault(m => m.Alter == 20);
           

        }

        private static bool FängtMitAAn(Mensch arg)
        {
            return arg.Name[0] == 'A';
        }

        public static bool Volljährig(Mensch mensch)
        {
            return mensch.Alter >= 18;
        }

        public static List<Mensch> Filtern(List<Mensch> menschen, Func<Mensch,bool> Filterkriterium)
        {
            List<Mensch> gefilterteMenschen = new List<Mensch>();
            foreach (var item in menschen)
            {
                if (Filterkriterium(item))
                {
                    gefilterteMenschen.Add(item);
                }
            }
            return gefilterteMenschen;
        }

        private static void GenerischeDictionaryMethode()
        {
            Dictionary<string, List<Mensch>> stadtAufEinwohnerTabelle = new Dictionary<string, List<Mensch>>();
            stadtAufEinwohnerTabelle.Add("Berlin", new List<Mensch>() { new Mensch("Alex", 5) });
            stadtAufEinwohnerTabelle["Berlin"].Add(new Mensch("Martin", 10));

            stadtAufEinwohnerTabelle.AddOrCreate("Leipzig", new Mensch("Olaf", 10));
            stadtAufEinwohnerTabelle.AddOrCreate("Leipzig", new Mensch("Martin", 10));
            //stadtAufEinwohnerTabelle.Add("Leipzig", new Mensch("Anna", 20));
            //stadtAufEinwohnerTabelle.Add("Leipzig", new Mensch("Martin", 20));

        }

        private static void GenerischeMethoden()
        {
            int x1 = 5;
            int x2 = 10;
            string s1 = "Haus";
            string s2 = "Stadt";
            Helper.Swap(ref x1, ref x2);
            //Helper.Swap(x1, x2, out x1, out x2);
            Console.WriteLine($"{x1} muss 10 sein");
            Console.WriteLine($"{x2} muss 5 sein");
            Helper.Swap<string>(ref s1, ref s2);
            Console.WriteLine($"{s1} muss Stadt sein");
            Console.WriteLine($"{s2} muss Haus sein");

            
            int z1 = 5;
            int z2 = 10;
            Console.WriteLine($"Quersumme: {z1.Quersumme()}");

            z1.SwapExt(ref z2);
            Console.WriteLine($"{z1} muss 10 sein");
            Console.WriteLine($"{z2} muss 5 sein");

        }

        private static void GenericsBeispiele()
        {
            int[] zahlen = new int[] { 2, 5, 4 };

            ArrayList list = new ArrayList();
            list.Add(5);
            //list.Add("asdasd");
            //list.Add(true);
            list.Add(10);

            int summe = 0;
            foreach (object item in list)
            {
                if (item is int zahl)
                {
                    //Unboxing
                    summe += zahl;
                }
                Console.WriteLine($"Summe: {summe}");
            }
            ThreeDPoint d = new ThreeDPoint();
            d.X = 5;
            d.Y = 4;
            ThreeDPoint dCopy = d;
            ValueType valueType = d;
            //Boxing
            object z = d;

            List<int> zahlenListe = new List<int>();
            zahlenListe.Add(5);
            zahlenListe.Add(15);
            zahlenListe.Add(20);

            int Summe = 0;
            foreach (var item in zahlenListe)
            {
                Summe += item;
            }
            Console.WriteLine($"Ergebnis:  {summe}");

            //Andere generische Datentypen
            Queue<int> reihe = new Queue<int>();
            reihe.Enqueue(5);
            reihe.Enqueue(15);
            reihe.Enqueue(20);
            //5
            int akutelleZahl = reihe.Dequeue();

            Stack<string> stapel = new Stack<string>();
            stapel.Push("Element 1");
            stapel.Push("Element 2");
            stapel.Push("Element 3");
            //Element 3
            string obersteKiste = stapel.Pop();

            Tuple<int, bool> tuple = new Tuple<int, bool>(5, true);
            Console.WriteLine($"Zahl: {tuple.Item1}, bool: {tuple.Item2}");

            var sortierteListe = zahlenListe.OrderBy(i => i);

            Dictionary<string, int> stadtEinwohnerListe = new Dictionary<string, int>();
            stadtEinwohnerListe.Add("Berlin", 3_700_000);
            stadtEinwohnerListe.Add("Leipzig", 600_000);
            Console.WriteLine($"Einwohner von Berlin: {stadtEinwohnerListe["Berlin"]}");

            Hashtable hashTable = new Hashtable();
            hashTable.Add(20, true);
            Dictionary<object, object> hippieDictionary = new Dictionary<object, object>();

            IObservable<int> beobachtbaresObjetk;

            Action<int> methodeMitIntegerParameterRückgabewertVoid = integerParam => Console.WriteLine(integerParam);

        }

        private static void MyListTest()
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(10);
            myList.Add(5);
            myList.Add(6);
            //myList.Add("adsasd");

            Console.WriteLine(myList[0]);
            myList[0] = 4;
            foreach (int item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }

    public struct ThreeDPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
