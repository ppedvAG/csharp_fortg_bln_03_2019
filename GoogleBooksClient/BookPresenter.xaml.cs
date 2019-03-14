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
    /// Interaction logic for BookPresenter.xaml
    /// </summary>
    public partial class BookPresenter : UserControl
    {

        //propdp
        public IBook CurrentBook
        {
            get { return (IBook)GetValue(CurrentBookProperty); }
            set { SetValue(CurrentBookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentBook.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentBookProperty =
            DependencyProperty.Register("CurrentBook", typeof(IBook), typeof(BookPresenter), new PropertyMetadata(null,BookChanged));

        private static void BookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is BookPresenter presenter && e.NewValue is IBook book)
            {
                presenter.tbTitle.Text = book.Title;
                presenter.tbDescription.Text = book.Description?.Substring(0, Math.Min(book.Description.Length ,1000));
                presenter.listAuthors.ItemsSource = book.Authors;
                AdjustButtonContent(presenter.btnFavorite, book);
                //zusätzlicher Code
                foreach (var plugin in Globals.Plugins)
                {
                    plugin.ExtendBookPresenter(book, presenter.mainPanel);
                }
            }
        }

        private static void AdjustButtonContent(Button btn, IBook book)
        {
            btn.Content = book.IsFavorite ? "\uE735" : " \uE734";
        } 

        public BookPresenter()
        {
            InitializeComponent();
        }

        private void Favorite_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentBook.IsFavorite)
            {
                Globals.FavoriteManager.RemoveFromFavoriteBooks(CurrentBook, () => AdjustButtonContent(btnFavorite, CurrentBook));
            }
            else
            {
                Globals.FavoriteManager.AddAsFavoriteBook(CurrentBook, () => AdjustButtonContent(btnFavorite, CurrentBook));
            }
        }
    }
}