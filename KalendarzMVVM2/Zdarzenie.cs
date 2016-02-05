using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalendarzMVVM2
{
    class Zdarzenie : INotifyPropertyChanged
    {
        private DateTime data;
        private string miejsce;
        private string opis;

        public DateTime Data { get { return data; }
            set
            {
                if (value == data) return;
                data = value;
                OnPropertyChanged("Data");
            }
        }

        public string Miejsce { get { return miejsce; }
            set
            {
                if (value == miejsce) return;
                miejsce = value;
                OnPropertyChanged("Miejsce");
            }
        }

        public string Opis { get { return opis; }
            set
            {
                if (value == opis) return;
                opis = value;
                OnPropertyChanged("Opis");
            }
        }


        private ObservableCollection<Zdarzenie> lista;
        public ObservableCollection<Zdarzenie> Lista
        {
            get { return lista; }
        }

        public Zdarzenie()
        {
            this.lista = new ObservableCollection<Zdarzenie>();
        }

        public Zdarzenie DodajZdarzenie(DateTime d, string m, string o)
        {
            Zdarzenie z = new Zdarzenie() { Data = d, Miejsce = m, Opis = o };
            this.lista.Add(z);
            return z;
        }

        /*public void UsunZdarzenie()
        {
            this.lista = null;
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string a_propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(a_propertyName));
            }
        }
    }
}
