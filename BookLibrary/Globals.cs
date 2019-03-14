using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BookLibrary
{
    public static class Globals
    {
        private static UnityContainer _container;
        public static UnityContainer Container => _container ?? (_container = new UnityContainer()); 


        //Singleton-Prinzip: Es darf nur eine Instanz der Klasse geben und diese
        //darf nur 1 Mal erzeugt werden
        private static IWebService _webService;
        public static IWebService WebService
        {
            get
            {
                if(_webService == null)
                {
                    _webService = Container.Resolve<IWebService>();
                }
                return _webService;
            }
        }

        private static IStorage _storage;
        //Kurzform der oberen Variante
        public static IStorage Storage => _storage ?? (_storage = Container.Resolve<IStorage>());

        private static FavoriteManager _favoriteManager;
        

        //Lazy Loading: wird erst initialisiert wenn es das erste Mal gebraucht wird
        public static FavoriteManager FavoriteManager => _favoriteManager ?? (_favoriteManager = new FavoriteManager());

        private static List<IBookPresenterPlugin> _plugins;
        public static List<IBookPresenterPlugin> Plugins => _plugins ?? (_plugins = new List<IBookPresenterPlugin>());


        //TODO: Dependency Injection
    }
}
