using Contracts;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace BookPlugin
{
    public class PreviewLinkExtension : IBookPresenterPlugin
    {
        #region Ohne Lambda
        //IBook _book;
        #endregion

        public void ExtendBookPresenter(IBook book, object panel)
        {
            if(panel is StackPanel spanel && !string.IsNullOrWhiteSpace(book.PreviewLink))
            {
                #region Ohne Lambda
                _book = book;
                #endregion
                Button newButton = new Button();
                newButton.Content = "Vorschauseite";
                newButton.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                newButton.Margin = new System.Windows.Thickness(10);
                newButton.Click += (sen, args) => Process.Start(book.PreviewLink);
                #region Ohne Lambda
                //newButton.Click += NewButton_Click;
                #endregion
                spanel.Children.Add(newButton);

                foreach (var item in spanel.Children)
                {
                    if(item is TextBlock block)
                    {
                        block.FontWeight = FontWeights.ExtraBold;
                    }
                }
            }
        }

        #region Ohne Lambda
        //private void NewButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Process.Start(_book.PreviewLink);
        //}
        #endregion
    }
}