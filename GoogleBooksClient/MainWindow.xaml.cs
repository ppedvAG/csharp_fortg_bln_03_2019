using BookLibrary;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        private void Search_Books_Click(object sender, RoutedEventArgs e)
        {
            FakeWebService fakeService = new FakeWebService();
            IEnumerable<IBook> books = fakeService.SearchBooks(tbSearchTerm.Text);
            listboxBooks.ItemsSource = books;
        }
    }
}
