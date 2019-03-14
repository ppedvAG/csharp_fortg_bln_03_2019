using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ReflectionTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (this.DataContext is ViewModel model)
            {
                ObservableCollection<Person> personen = model.Personen;

                var properties = typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var property in properties)
                {
                    //TODO: Auf Attribut checken
                    if (property.GetCustomAttribute<NonSortableAttribute>() != null)
                        continue;
                    Button newButton = new Button();
                    var desc = property.GetCustomAttribute<SortingDescriptionAttribute>();
                    if(desc == null)
                        newButton.Content = $"nach {property.Name} sortieren";
                    else
                        newButton.Content = $"nach {desc.Description} sortieren";

                    newButton.Click += (_, _2) =>
                    {
                        model.Personen = new ObservableCollection<Person>(personen.OrderBy(p =>
                        {
                            object v = property.GetValue(p);
                            return v;
                        }).ToList());
                    };
                    stackpanel.Children.Add(newButton);
                }
            }
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _personen = new ObservableCollection<Person>()
        {
            new Person("Alfon", 40, 20),
            new Person("Martin", 10, 40),
            new Person("Anna", 30, 200),
            new Person("Fritz", 70, 30)
        };

        public ObservableCollection<Person> Personen
        {
            get => _personen; set
            {
                _personen = value;
                PropertyChanged?.Invoke(this, new
                    PropertyChangedEventArgs(nameof(Personen)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
