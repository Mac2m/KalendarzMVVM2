using KalendarzMVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KalendarzMVVM2
{
    class ZdarzenieViewModel : ICommand, INotifyPropertyChanged

    {
        Zdarzenie zk = new Zdarzenie();
        public ICommand SaveCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }

        public Zdarzenie Wybrane { get; set; }

        public ZdarzenieViewModel()
        {
            this.PrzykladoweDane();
            

            this.SaveCommand = new RelayCommand(
                param => this.DodajZdarzenie(),
                param => this.CzyMoznaDodacZdarzenie());
            this.ClearCommand = new RelayCommand(
                a => this.WyczyscWybraneZdarzenie(),
                b => this.CzyMoznaUsunacZdarzenie());
        }

        public void PrzykladoweDane()
        {
            zk.DodajZdarzenie(new DateTime(2016, 1, 10), "Toruń", "Testowy opis");
            zk.DodajZdarzenie(new DateTime(2016, 10, 23), "Gdańsk", "Testowy opis numer 2");
        }

        public void DodajZdarzenie()
        {
            zk.DodajZdarzenie(DateTime.Today, "Warszawa", "Bieg na 5 km");
        }

        private bool CzyMoznaDodacZdarzenie()
        {
            return true;
        }

        private bool CzyMoznaUsunacZdarzenie()
        {
            if (Zk.Lista == null)
                return false;
            else
                return true;
        }

        private void WyczyscWybraneZdarzenie()
        {
            if (this.Zk.Lista != null)
                this.Zk.Lista.Remove(Wybrane);
            else
                MessageBox.Show("Lista jest już pusta!!");
        }

        public Zdarzenie Zk
        {
            get
            {
                return this.zk;
            }
            set
            {
                this.zk = value;
                this.OnPropertyChanged("Lista");
            }
        }

        

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string a_propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(a_propertyName));
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Zk.DodajZdarzenie(DateTime.Today, "Warszawa", "studia Programowanie .NET");
        }
    }
}
