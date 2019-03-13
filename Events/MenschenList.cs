using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class MenschenList : ObservableCollection<Mensch>
    {
        public static int Limit { get; set; } = 3;

        public enum ErrorKind { List, Individual };

        public event EventHandler<(ErrorKind kind, string message)> Error;


        #region ausprogrammierter Event-Wrapper
        public event EventHandler<(ErrorKind kind, string message)> Dummy
        {
            add
            {
                Error += value;
            }
            remove
            {
                Error -= value;
            }
        }
        #endregion


        public new void Add(Mensch neuerMensch)
        {
            if(base.Count < Limit )
            {
                neuerMensch.Error += NeuerMensch_Error;
                neuerMensch.PropertyChanged += NeuerMensch_PropertyChanged;
                base.Add(neuerMensch);
            }
            else
            {
                Error?.Invoke(this, (ErrorKind.List, $"Es darf maximal {Limit} Menschen geben!"));
            }
        }

        private void NeuerMensch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Ruft beim PropertyChanged-Event der Mensch-Klasse  automatisch das CollectionChanged-Event von ObservableCollection aus,
            //damit die ListBox getriggert wird, die ToString()-Methode aller Items neu aufzurufen!
            OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
        }

        private void NeuerMensch_Error(object sender, (ErrorKind kind, string message) e)
        {
            Error?.Invoke(this, e);
        }
    }
}
