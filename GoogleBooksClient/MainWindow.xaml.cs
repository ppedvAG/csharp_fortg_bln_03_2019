using BookLibrary;
using Contracts;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoogleBooksClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
            tbSearchTerm.Focus();

            //Sortierungsbuttons vorbereiten
            foreach (var property in typeof(Book).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {

                if(property.GetCustomAttribute<InvisibleAttribute>() != null)
                {
                    continue;
                }




                SortButtonTitleAttribute titleAttribute = property.GetCustomAttribute<SortButtonTitleAttribute>();
                string buttonContent = titleAttribute != null ? titleAttribute.Label : property.Name;

                Button newButton = new Button();
                newButton.Content = $"nach {buttonContent}";
                newButton.Click += (sen, args) =>
                {
                    if (_lastResult != null)
                    {
                        if (property.PropertyType.GetInterface(nameof(ICollection)) != null)
                        {
                            listboxBooks.ItemsSource = _lastResult = _lastResult.OrderBy(b => { return (property.GetValue(b) as ICollection).Count; }).ToList();
                        }
                        else
                        {

                            listboxBooks.ItemsSource = _lastResult = _lastResult.OrderBy(b => { return property.GetValue(b); }).ToList();
                        }

                    }
                };
                sortPanel.Children.Add(newButton);
            }
        }

        IEnumerable<IBook> _lastResult;

        private void Search_Books_Click(object sender, RoutedEventArgs e)
        {
            _lastResult = Globals.WebService.SearchBooks(tbSearchTerm.Text);
            Globals.FavoriteManager.MarkBooksAsFavorite(_lastResult);
            listboxBooks.ItemsSource = _lastResult;
        }

        private void Show_Favorites_Click(object sender, RoutedEventArgs e)
        {
            var favoriteBooks = Globals.FavoriteManager.FavoriteBooks;
            listboxBooks.ItemsSource = favoriteBooks.Values;
        }

        private void Install_Plugin_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Plugins|*.dll";
            if (dialog.ShowDialog() == true)
            {
                //eigene Assembly analysieren
                //Assembly.GetExecutingAssembly();
                Assembly plugin = Assembly.LoadFile(dialog.FileName);
                foreach (Type type in plugin.GetTypes())
                {
                    //Alternativ: type.GetInterface(nameof(IBookPresenterPlugin));
                    foreach (Type interf in type.GetInterfaces())
                    {
                        if (interf == typeof(IBookPresenterPlugin))
                        {
                            var pluginInstance = (IBookPresenterPlugin)Activator.CreateInstance(type);
                            if (!Globals.Plugins.Contains(pluginInstance))
                            {
                                Globals.Plugins.Add(pluginInstance);
                            }
                            break;
                        }
                    }

                }
            }
        }
    }
}
