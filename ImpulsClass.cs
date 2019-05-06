using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Metrology
{
    class ImpulsClass : INotifyPropertyChanged
    {
        public ImpulsClass(){
            
        }

        private double vih;
        public double Vih
        {
            get { return vih; }
            set { vih = value; OnPropertyChanged(); }
        }

        private double vil;
        public double Vil
        {
            get { return vil; }
            set { vil = value; OnPropertyChanged(); }
        }

        private double period;
        public double Period
        {
            get { return period; }
            set { period = value; OnPropertyChanged(); }
        }


        public void launch()
        {
            int plate = MainVM.plate;




        }

        public void stop()
        {
            int plate = MainVM.plate;


        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
