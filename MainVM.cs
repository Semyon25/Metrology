using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Metrology
{
    class MainVM : INotifyPropertyChanged
    {

        public MainVM()
        {
            AmountPlates = 5;
            Plates = new ObservableCollection<int>();
            Channels = new ObservableCollection<int>();
            for (int i = 1; i <= 16; i++) Channels.Add(i);
        }


        private int amountPlates;
        public int AmountPlates
        {
            get { return amountPlates; }
            set { amountPlates = value; OnPropertyChanged(); }
        }
        private ObservableCollection<int> channels;
        public ObservableCollection<int> Channels
        {
            get { return channels; }
            set { channels = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> plates;
        public ObservableCollection<int> Plates
        {
            get { return plates; }
            set { plates = value; OnPropertyChanged(); }
        }

        private int plate;
        public int Plate
        {
            get { return plate; }
            set { plate = value; OnPropertyChanged(); }
        }
        private bool initState;
        public bool InitState
        {
            get { return initState; }
            set { initState = value; OnPropertyChanged(); }
        }















        #region ICommand Initialization
        private ICommand initialization;
        public ICommand Initialization
        {
            get
            {
                if (initialization == null)
                    initialization = new MyCommand(InitializationButton, () => { return true; });
                return initialization;
            }
        }
        public void InitializationButton()
        {
            if (InitState)
            {
                Plates.Clear();

                Plate = -1;
                InitState = !InitState;
            }
            else
            {
            for(int i=1; i<=AmountPlates; i++)
                Plates.Add(i);

                InitState = !InitState;
            }
        }
        #endregion




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
