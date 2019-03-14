using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BookPlugin
{
    public class ImageExtension : IBookPresenterPlugin
    {
        public void ExtendBookPresenter(IBook book, object panel)
        {
            if(panel is StackPanel spanel && !string.IsNullOrWhiteSpace(book.CoverURL))
            {
                Image image = new Image();
                image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(book.CoverURL);
                image.Height = 100;
                spanel.Children.Add(image);
            }
        }
    }
}
