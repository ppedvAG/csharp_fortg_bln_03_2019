using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Events
{
    public class Mensch : INotifyPropertyChanged
    {
        private int _alter;
        private string _name;

        public event EventHandler<(MenschenList.ErrorKind kind, string message)> Error;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => _name; set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        public int Alter
        {
            //Expression Body Member
            get => _alter;
            set
            {
                if (value < _alter)
                {
                    Error?.Invoke(this, (MenschenList.ErrorKind.Individual, "Verjüngung nicht erlaubt!"));
                    return;
                }
                _alter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        public Mensch(string name, int alter)
        {
            Name = name;
            Alter = alter;
        }

        public override string ToString()
        {
            return $"{Name} ({Alter} Jahre alt)";
        }
    }
}