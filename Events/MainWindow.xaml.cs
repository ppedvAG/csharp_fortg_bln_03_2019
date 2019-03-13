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

namespace Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MenschenList _menschenliste = new MenschenList();

        public MainWindow()
        {
            InitializeComponent();

            _menschenliste.Error += _menschenliste_Error;

            _menschenliste.Add(new Mensch("Alex Schulz", 20));
            _menschenliste.Add(new Mensch("Steffie Graf", 40));

            

            listbox.ItemsSource = _menschenliste;

            MessageBox.Show("adsdasdsa");
        }

        private void _menschenliste_Error(object sender, (MenschenList.ErrorKind kind, string message) e)
        {
            MessageBox.Show(e.message);
        }

        private void Neuer_Mensch_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int alter = (int)sliderAlter.Value;

            Mensch neuerMensch = new Mensch(name, alter);
            _menschenliste.Add(neuerMensch);
        }

        private void Mensch_Verjüngen_Click(object sender, RoutedEventArgs e)
        {
            if(listbox.SelectedItem is Mensch mensch)
            {
                mensch.Alter--;
            }
        }

        private void Mensch_Altern_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedItem is Mensch mensch)
            {
                mensch.Alter++;
            }
        }
    }
}
