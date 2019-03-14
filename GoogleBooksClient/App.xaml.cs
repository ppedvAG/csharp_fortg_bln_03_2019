using BookLibrary;
using Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace GoogleBooksClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Bootstrapping
#if DEBUG
            Globals.Container.RegisterType<IStorage, FakeStorage>();
            Globals.Container.RegisterType<IWebService, FakeWebService>();
#else
            Globals.Container.RegisterType<IStorage, RealStorage>();
            Globals.Container.RegisterType<IWebService, RealWebService>();
#endif

            base.OnStartup(e);
        }
    }
}
